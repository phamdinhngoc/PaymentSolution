using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Application.Features.Commands
{
    public class SetActivePaymentDestination
    {
        public string Id { get; set; } = string.Empty;
        public bool IsActive { get; set; }  
    }
}
