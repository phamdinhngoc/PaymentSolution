using System;
using System.Collections.Generic;
using System.Text;
using Payment.Domain.Entities;

namespace Payment.Application.Features.Dtos
{
    public class MerchantDtos 
    {
        public string Id { get; set; } = string.Empty;
        public string MerchantName { get; set; } = string.Empty;
        public string MerchantWebLink { get; set; } = string.Empty;
        public string MerchantIpnUrl { get; set; } = string.Empty;
        public string MerchantReturnUrl { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
