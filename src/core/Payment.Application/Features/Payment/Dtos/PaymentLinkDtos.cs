using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Application.Features.Dtos
{
    public class PaymentLinkDtos
    {
        public string PaymentId { get; set; } = string.Empty;
        public string PaymentUrl { get; set; } = string.Empty;
    }
}
