using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Core.Entities;

namespace UserService.Application.Interfaces.Services
{
    public interface IUserManagerService
    {
        Task<bool> CreateAsync(ApplicationUser userRegister, string password, string userRoleName);
    }
}
