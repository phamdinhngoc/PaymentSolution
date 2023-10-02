using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payment.Application.Base.Models;
using Payment.Application.Features.Commands;
using Payment.Application.Features.Dtos;
using System.Net;
using System.Threading.Tasks;

namespace Payment.API.Controllers
{
    [Route("api/payments")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IMediator mediator;
        public PaymentsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(BaseResultWithData<PaymentLinkDtos>), 200)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreatePayment request)
        {
            var response  = new BaseResultWithData<PaymentLinkDtos>();
            response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
