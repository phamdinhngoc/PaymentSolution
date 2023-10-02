using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Domain.Entities
{
    public class PaymentTransaction
    {
        public string Id { get; set; }
        public string TranMessage { get; set; }
        public string TranPayload { get; set; }
        public string TranStatus { get; set; }
        public string TranAmount { get; set; }
        public DateTime TranDate { get; set; }
        public string PaymentId { get; set; }
        public string TranRefId { get; set; }
    }
}
