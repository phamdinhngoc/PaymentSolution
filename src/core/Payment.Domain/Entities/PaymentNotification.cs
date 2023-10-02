using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Domain.Entities
{
    public class PaymentNotification
    {
        public string Id { get; set; }
        public string PaymentRefId { get; set; }
        public DateTime NotiDate { get; set; }
        public string NotiContent { get; set; }
        public decimal NotiAmount { get; set; }
        public string NotiMessage { get; set; }
        public string NotiSignature { get; set; }
        public string NotiPaymentId { get; set; }
        public string NotiMerchantId { get; set; }
        public string NotiStatus { get; set; }
        public DateTime NotiResDate { get; set; }
        public string NotiResMessage { get; set; }
        public string NotiResHttpCode { get; set; }
    }
}
