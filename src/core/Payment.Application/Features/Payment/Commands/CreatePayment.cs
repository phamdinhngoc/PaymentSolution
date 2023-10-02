using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Payment.Application.Base.Models;
using Payment.Application.Constants;
using Payment.Application.Features.Dtos;
using Payment.Application.Interface;
using Payment.Services.VNPay.Config;
using Payment.Services.VNPay.Request;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Payment.Application.Features.Commands
{
    public class CreatePayment : IRequest<BaseResultWithData<PaymentLinkDtos>>
    {
        public string PaymentContent { get; set; } = string.Empty;
        public string PaymentCurrency { get; set; } = string.Empty;
        public string PaymentRefId { get; set; } = string.Empty;
        public decimal RequiredAmount { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public DateTime ExpireDate { get; set; } = DateTime.Now.AddMinutes(10);
        public string PaymentLanguage { get; set; }
        public string MerchantId { get; set; }
        public string PaymentDestinationId { get; set; } = string.Empty;
        public string Signature { get; set; } = string.Empty;
    }

    public class CreatePaymentHandler : IRequestHandler<CreatePayment, BaseResultWithData<PaymentLinkDtos>>
    {
        private readonly ISqlService sqlService;
        private readonly ICurrentUserService currentUserService;
        private readonly IConnectionService connectionService;
        private readonly VnpayConfig vnpayConfig;
        public CreatePaymentHandler(ICurrentUserService currentUserService, IConnectionService connectionService,ISqlService sqlService,IOptions<VnpayConfig> vnpayConfigOptions)
        {
            this.currentUserService = currentUserService;
            this.connectionService = connectionService;
            this.sqlService = sqlService;
            this.vnpayConfig = vnpayConfigOptions.Value;
        }
        public Task<BaseResultWithData<PaymentLinkDtos>> Handle(CreatePayment request, CancellationToken cancellationToken)
        {
            var result = new BaseResultWithData<PaymentLinkDtos>();

            try
            {
                string connectionString = connectionService.Database ?? string.Empty;
                var outputIdParam = sqlService.CreateOutputParameter("@InsertedId", SqlDbType.NVarChar, 50);
                var parameter = new SqlParameter[]
                {
                    new SqlParameter("@Id",DateTime.Now.Ticks.ToString()),
                    new SqlParameter("@PaymentContent",request.PaymentContent),
                    new SqlParameter("@PaymentCurrency",request.PaymentCurrency??string.Empty),
                    new SqlParameter("@PaymentRefId",request.PaymentRefId??string.Empty),
                    new SqlParameter("@RequiredAmount",request.RequiredAmount),
                    new SqlParameter("@PaymentDate",  DateTime.Now),
                    new SqlParameter("@ExprireDate", DateTime.Now.AddMinutes(10)),
                    new SqlParameter("@PaymentLanguage",request.PaymentLanguage??string.Empty),
                    new SqlParameter("@MerchantId",request.MerchantId ?? string.Empty),
                    new SqlParameter("@PaymentDestinationId",request.PaymentDestinationId ?? string.Empty),
                    new SqlParameter("@Signature",request.Signature ?? string.Empty),
                    new SqlParameter("@InsertUser",currentUserService.UserId ?? string.Empty),
                    outputIdParam
                };
                (int affectedRows,string sqlError) = sqlService.ExecuteNonQuery(connectionString,PaymentConstants.InsertSprocName,parameter);
                if(affectedRows > 1)
                {
                    var paymentUrl = string.Empty;

                    switch (request.PaymentDestinationId)
                    {
                        case "VNPAY":
                            var vnpayPayRequest = new VnpayPayRequest(vnpayConfig.Version, vnpayConfig.tmnCode,
                                DateTime.Now, currentUserService.IpAddress ?? string.Empty, request.RequiredAmount , request.PaymentCurrency ?? string.Empty,
                                "other", request.PaymentContent ?? string.Empty, vnpayConfig.ReturnUrl, outputIdParam!.Value?.ToString() ?? string.Empty);
                            paymentUrl = vnpayPayRequest.GetLink(vnpayConfig.PaymentUrl, vnpayConfig.HashSecret);
                            break;
                        default:
                            break;
                    }
                    result.Set(true, MessageConstants.OK, new PaymentLinkDtos()
                    {
                        PaymentId = outputIdParam!.Value?.ToString()??string.Empty,
                        PaymentUrl = paymentUrl,    
                    });
                }
                else
                {
                    result.Set(false, MessageConstants.Error);
                    result.Errors.Add(new BaseError()
                    {
                        Code = "sql",
                        Message = sqlError
                    });

                }
            }
            catch (Exception ex)
            {
                result.Set(false, MessageConstants.Error);
                result.Errors.Add(new BaseError()
                {
                    Code = MessageConstants.Exception,
                    Message = ex.Message,
                });
            }
            return Task.FromResult(result);
        }
    }
}
