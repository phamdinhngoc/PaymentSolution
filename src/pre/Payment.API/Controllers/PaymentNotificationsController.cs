using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payment.Application.Base.Models;
using Payment.Domain.Entities;
using System.Collections.Generic;
using System.Net;

namespace Payment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentNotificationsController : ControllerBase
    {
        /// <summary>
        /// get notification base on criteria
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(BaseResultWithData<List<PaymentNotification>>),200)]
        [ProducesResponseType(400)]
        public IActionResult Get(string criteria)
        {
            var response = new BaseResultWithData<List<PaymentNotification>>();
            return Ok(response);
        }
        /// <summary>
        /// get notifications paging
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("with-paging")]
        [ProducesResponseType(typeof(BaseResultWithData<BasePagingData<PaymentNotification>>),200)]
        public IActionResult GetPaging([FromQuery] BasePagingQuery query)
        {
            var response = new BaseResultWithData<BasePagingData<PaymentNotification>>();
            return Ok(response);
        }
        /// <summary>
        /// get one notification by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(BaseResultWithData<PaymentNotification>),200)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetOne([FromRoute]string id)
        {
            var response = new BasePagingData<PaymentNotification>();
            return Ok(response);
        }


    }
}
