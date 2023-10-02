using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Domain.Common
{
    public class BaseAuditableEntity
    {
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string LastUpdatedBy { get; set; } = string.Empty;
        public DateTime LastUpdatedAt { get; set; }
    }
}
