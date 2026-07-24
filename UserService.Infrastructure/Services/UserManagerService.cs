using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Shared.Contracts.Exceptions;
using UserService.Application.Interfaces.Services;
using UserService.Core.Abstractions.Persistence;
using UserService.Core.Entities;

namespace UserService.Infrastructure.Services
{
    public class UserManagerService : IUserManagerService
    {
        private readonly ILogger<UserManagerService> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserValidationService _userValidationService;
        private readonly IUnitOfWork _unitOfWork;
        public UserManagerService(ILogger<UserManagerService> logger, 
            UserManager<ApplicationUser> userManager,
            IUserValidationService userValidationService,
            IUnitOfWork unitOfWork) { 
            _logger = logger;
            _userManager = userManager;
            _userValidationService = userValidationService;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// thêm mới user vào hệ thống và gán quyền cho user đó
        /// </summary>
        /// <param name="userRegister"></param>
        /// <param name="password"></param>
        /// <param name="userRoleName"></param>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        public async Task<bool> CreateAsync(ApplicationUser userRegister, string password, string userRoleName)
        {
            if (userRegister == null 
                || string.IsNullOrEmpty(userRegister.UserName) 
                || string.IsNullOrEmpty(userRegister.Email)
                || string.IsNullOrEmpty(userRegister.PhoneNumber))
            {
                throw new BadRequestException("Thông tin đăng ký không đúng định dạng.");
            }
            await _userValidationService.EnsureEmailUniqueAsync(userRegister.Email);
            await _userValidationService.EnsureUserNameUniqueAsync(userRegister.UserName);
            await _userValidationService.EnsurePhoneNumberUniqueAsync(userRegister.PhoneNumber);

            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var result = await _userManager.CreateAsync(userRegister, password);
                if (!result.Succeeded)
                {
                    var errors = result.Errors.Select(e => e.Description).ToList();
                    throw new BadRequestException("Đăng ký thất bại", errors);
                }

                var roleResult = await _userManager.AddToRoleAsync(userRegister, userRoleName);
                if (!roleResult.Succeeded)
                {
                    var errors = roleResult.Errors.Select(e => e.Description).ToList();
                    throw new BadRequestException("Không thể gán quyền cho người dùng.", errors);
                }

                await _unitOfWork.CommitAsync();
                _logger.LogInformation("Đã tạo user mới: {UserName}", userRegister.UserName);
                return true;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
               
                throw;
            }
          
        }

    }
}
