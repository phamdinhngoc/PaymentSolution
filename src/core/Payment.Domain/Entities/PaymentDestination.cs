using Payment.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Domain.Entities
{ 
    public class PaymentDestination : BaseAuditableEntity
    {
        public string Id { get; set; }
        public string DesName { get; set; }
        public string DesShortName { get; set;}
        public string DesParentId { get; set; }
        public string DesLogo { get; set; }
        public int ShortIndex { get; set; }
        public bool IsActive { get; set; }

    }
}
