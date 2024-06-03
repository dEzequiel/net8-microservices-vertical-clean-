using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crosscuting.Base.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(string? message) : base(message) { }
        public UnauthorizedException(string? message, string? details) : base(message) { }

        public string? Details { get; }
    }
}
