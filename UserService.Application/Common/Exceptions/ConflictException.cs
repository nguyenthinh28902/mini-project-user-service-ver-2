using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Application.Common.Models;

namespace UserService.Application.Common.Exceptions
{
    public class ConflictException : BaseException
    {
        public ConflictException(string msg) : base(msg, 409, null) { }
    }
}
