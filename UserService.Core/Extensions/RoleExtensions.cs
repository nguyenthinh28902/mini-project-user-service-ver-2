using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Core.Enums;

namespace UserService.Core.Extensions
{
    public static class RoleExtensions
    {
        public static string ToRoleString(this RoleType role)
        {
            return role.ToString();
        }
    }
}
