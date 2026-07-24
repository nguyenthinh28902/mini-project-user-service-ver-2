using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shared.Contracts.Exceptions;
using UserService.Application.Interfaces.Services;
using UserService.Core.Entities;

namespace UserService.Infrastructure.Services
{
    public class UserValidationService : IUserValidationService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserValidationService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        /// <summary>
        /// kiểm tra email có tồn tại trong hệ thống hay chưa, nếu tồn tại thì ném ra ConflictException
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        /// <exception cref="ConflictException"></exception>
        public async Task EnsureEmailUniqueAsync(string email)
        {
            if (await _userManager.FindByEmailAsync(email) != null)
                throw new ConflictException("Email đã tồn tại.");
        }

        /// <summary>
        /// kiểm tra tên đăng nhập có tồn tại trong hệ thống hay chưa, nếu tồn tại thì ném ra ConflictException
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        /// <exception cref="ConflictException"></exception>
        public async Task EnsureUserNameUniqueAsync(string userName)
        {
            if (await _userManager.FindByNameAsync(userName) != null)
                throw new ConflictException("Tên đăng nhập đã tồn tại.");
        }

        /// <summary>
        /// kiểm tra số điện thoại có tồn tại trong hệ thống hay chưa, nếu tồn tại thì ném ra ConflictException
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        /// <exception cref="ConflictException"></exception>
        public async Task EnsurePhoneNumberUniqueAsync(string phoneNumber)
        {
            if (await _userManager.Users.AnyAsync(u => u.PhoneNumber == phoneNumber))
                throw new ConflictException("Số điện thoại đã được sử dụng.");
        }
    }
}
