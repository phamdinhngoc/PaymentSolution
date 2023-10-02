using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Application.Interface
{
    public interface IConnectionService
    {
        string Database { get; }
    }
}
