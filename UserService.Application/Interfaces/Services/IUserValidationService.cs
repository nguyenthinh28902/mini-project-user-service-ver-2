using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Application.Interfaces.Services
{
    public interface IUserValidationService
    {
        Task EnsureEmailUniqueAsync(string email);
        Task EnsureUserNameUniqueAsync(string userName);
        Task EnsurePhoneNumberUniqueAsync(string phoneNumber);
    }
}
