using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Application.Common.Models;

namespace UserService.Application.Common.Exceptions
{
    public class BadRequestException : BaseException 
    {
        public BadRequestException(string msg, List<string>? err = null) : base(msg, 400, err) { } 
    }
}
