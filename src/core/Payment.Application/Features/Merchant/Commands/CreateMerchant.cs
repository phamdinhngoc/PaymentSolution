using Mapster;
using MediatR;
using Payment.Application.Base.Models;
using Payment.Application.Constants;
using Payment.Application.Features.Dtos;
using Payment.Application.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Payment.Application.Features.Commands
{
    public class CreateMerchant : IRequest<BaseResultWithData<MerchantDtos>>
    {
        public string MerchantName { get; set; } = string.Empty;
        public string MerchantWebLink { get; set; } = string.Empty;
        public string MerchantIpnUrl { get; set; } = string.Empty;
        public string MerchantReturnUrl { get; set; } = string.Empty;
        
    }
    public class CreateMerchantHandler : IRequestHandler<CreateMerchant, BaseResultWithData<MerchantDtos>>
    {
        private readonly ICurrentUserService currentUserService;
        private readonly ISqlService sqlService;
        private readonly IConnectionService connectionService;

        public CreateMerchantHandler(ICurrentUserService currentUserService, ISqlService sqlService, IConnectionService connectionService)
        {
            this.currentUserService = currentUserService;
            this.sqlService = sqlService;
            this.connectionService = connectionService;
        }

        public Task<BaseResultWithData<MerchantDtos>> Handle(CreateMerchant request, CancellationToken cancellationToken)
        {
            var result = new BaseResultWithData<MerchantDtos>();
            try
            {
                string connectionString = connectionService.Database ?? string.Empty;
                var outputIdParam = sqlService.CreateOutputParameter("@InsertedId", SqlDbType.NVarChar, 50);
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@MerchantName",request.MerchantName ?? string.Empty),
                    new SqlParameter("@MerchantWebLink",request.MerchantWebLink ?? string.Empty),
                    new SqlParameter("@MerchantIpnUrl",request.MerchantIpnUrl ?? string.Empty),
                    new SqlParameter("@MerchantReturnUrl",request.MerchantReturnUrl ?? string.Empty),

                    new SqlParameter("@InsertUser",currentUserService.UserId ?? string.Empty)
                    //outputIdParam
                };
                (int affectedRows, string sqlError) = sqlService.ExecuteNonQuery(connectionString, MerchantConstants.InsertSprocName, parameters);
                if (affectedRows == 1)
                {
                    var resultData = request.Adapt<MerchantDtos>();
                    resultData.Id = outputIdParam.Value?.ToString() ?? string.Empty;
                    result.Set(true, MessageConstants.OK, resultData);
                }
                else
                {
                    result.Set(false, MessageConstants.Error);
                    result.Errors.Add(new BaseError()
                    {
                        Code = "Sql",
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
