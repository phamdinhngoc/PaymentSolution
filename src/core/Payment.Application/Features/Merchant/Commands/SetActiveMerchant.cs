using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Application.Features.Commands
{
    public class SetActiveMerchant
    {
        public string Id { get; set; }
        public bool IsActive { get; set; }  

    }
}
