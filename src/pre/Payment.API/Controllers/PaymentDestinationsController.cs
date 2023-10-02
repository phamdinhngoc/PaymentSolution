using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payment.Application.Base.Models;
using Payment.Application.Features.Commands;
using Payment.Application.Features.Dtos;
using System.Collections.Generic;
using System.Net;

namespace Payment.API.Controllers
{
    [Route("api/payment-destinations")]
    [ApiController]
    public class PaymentDestinationsController : ControllerBase
    {
        ///<summary>
        ///get Payment Destination base on criteria
        ///</summary>
        ///<param name="criteria"></param>
        ///<return></return>

        [HttpGet]
        [ProducesResponseType(typeof(BaseResultWithData<List<PaymentDestinationDtos>>), 200)]
        [ProducesResponseType(400)]
        public IActionResult Get(string criteria)
        {
            var response = new BaseResultWithData<List<PaymentDestinationDtos>>();
            return Ok(response);
        }
        /// <summary>
        /// Get payment destination paging
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("with-paging")]
        [ProducesResponseType(typeof(BaseResultWithData<BasePagingData<PaymentDestinationDtos>>),200)]
        public IActionResult GetPaging([FromQuery] BasePagingQuery query)
        {
            var response = new BaseResultWithData<BasePagingData<PaymentDestinationDtos>>();
            return Ok(response);
        }
        /// <summary>
        /// get one payment destiantion by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(BaseResultWithData<PaymentDestinationDtos>),200)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetOne([FromRoute] string id)
        {
            var response = new BaseResultWithData<PaymentDestinationDtos>();
            return Ok(response);
        }
        /// <summary>
        /// Create destination
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <remarks>
        /// POST /payment-destinations
        /// {
        ///     "DesName" : "Cổng thanh toán VNPay",
        ///     "DesShortName" : "VNPay Pay",
        ///     "DesParentId" : null,
        ///     "DesLogo" : "https://sandbox.vnpayment.vn/apis/assets/images/partner_deeplink.png",
        ///     "SortIndex" : 0
        /// }
        /// </remarks>
        [HttpPost]
        [ProducesResponseType(typeof(BaseResultWithData<PaymentDestinationDtos>),200)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Create([FromBody] CreatePaymentDestination request)
        {
            var response = new BaseResultWithData<PaymentDestinationDtos>();
            return Ok(response);
        }
        /// <summary>
        /// update payment destination
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(BaseResult),(int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Update(string id, [FromBody] UpdatePaymentDestination request)
        {
            var response = new BaseResult();
            return Ok(response);
        }
        /// <summary>
        /// Set active
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}/set-active")]
        [ProducesResponseType(typeof(BaseResult),(int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult SetActive(string id, [FromBody] SetActivePaymentDestination request) 
        {
            var response = new BaseResult();
            return Ok(response);
        }
        /// <summary>
        /// delete payment destination
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(BaseResult),(int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Delete(string id)
        {
            var response = new BaseResult();
            return Ok(response);
        }
    }
}
