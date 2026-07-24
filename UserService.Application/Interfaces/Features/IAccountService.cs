using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Application.Models.Dtos.User.Account;
using UserService.Application.Models.Dtos.User.Identity;

namespace UserService.Application.Interfaces.Features
{
    public interface IAccountService
    {
        Task<UserValidation> CheckInforUserRegisterAsync(string userInfor);
        Task<bool> RegisterAsync(UserRegisterRequest request);
    }
}
