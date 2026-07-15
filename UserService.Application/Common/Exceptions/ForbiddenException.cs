using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Application.Common.Models;

namespace UserService.Application.Common.Exceptions
{
    public class ForbiddenException : BaseException 
    {
        public ForbiddenException(string msg, List<string>? errors = null) : base(msg, 403, errors) 
        { }
    }
}
