using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Application.Common.Models
{
    public abstract class BaseException : Exception
    {
        public int StatusCode { get; }
        public List<string> Errors { get; } = new();
        protected BaseException(string message, int statusCode, List<string>? errors)
            : base(message) { StatusCode = statusCode; Errors = errors ?? new(); }
    }
}
