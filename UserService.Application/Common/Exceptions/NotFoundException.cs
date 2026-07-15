using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Application.Common.Models;

namespace UserService.Application.Common.Exceptions
{
    public class NotFoundException : BaseException 
    { 
        public NotFoundException(string msg, List<string>? errors = null) : base(msg, 404, errors) {
        } 
    }
}
