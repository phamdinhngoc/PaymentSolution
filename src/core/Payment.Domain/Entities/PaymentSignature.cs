using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Domain.Entities
{
    public class PaymentSignature
    {
        public string Id { get; set; }
        public string PaymentId { get; set; }
        public string SignValue { get; set; }
        public string SignAlgo { get; set; }
        public string SignOwn { get; set; }
        public DateTime SignDate { get; set; }
        public bool IsValid { get; set; }
    }
}
