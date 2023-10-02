using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Payment.Application.Base.Models
{
    public class BaseError
    {
        
        public string Code { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}
