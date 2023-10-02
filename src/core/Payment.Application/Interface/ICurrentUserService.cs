using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Application.Interface
{
    public interface ICurrentUserService
    {
        string UserId { get; }
        string IpAddress { get; }
    }
}
