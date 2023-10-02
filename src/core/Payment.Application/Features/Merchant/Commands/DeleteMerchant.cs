using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Application.Features.Commands
{
    public class DeleteMerchant
    {
        public string MerchantName { get; set; } = string.Empty;
        public string MerchantWebLink { get; set; } = string.Empty;
        public string MerchantIpnUrl { get; set; } = string.Empty;
        public string MerchantReturnUrl { get; set; } = string.Empty;

    }
}
