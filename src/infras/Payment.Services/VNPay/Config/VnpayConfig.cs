using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Services.VNPay.Config
{
    public class VnpayConfig
    {
        public static string ConfigName = "Vnpay";
        public string Version { get; set; } = string.Empty;
        public string tmnCode { get; set; } = string.Empty;
        public string HashSecret { get; set; } = string.Empty;
        public string ReturnUrl { get; set; } = string.Empty;
        public string PaymentUrl { get; set;} = string.Empty;
    }
}
