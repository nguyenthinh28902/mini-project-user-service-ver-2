using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Shared.Contracts.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Application.Interfaces.Features;
using UserService.Application.Interfaces.Services;
using UserService.Application.Models.Dtos.User.Account;
using UserService.Application.Models.Dtos.User.Identity;
using UserService.Core.Entities;
using UserService.Core.Enums;
using UserService.Core.Extensions;

namespace UserService.Application.Features
{
    public class AccountService : IAccountService
    {
        private readonly ILogger<AccountService> _logger;
        private readonly IUserValidationService _userValidationService;
        private readonly IUserManagerService _userManagerService;
        private readonly IMapper _mapper;
        public AccountService(ILogger<AccountService> logger,
            IUserValidationService userValidationService,
            IUserManagerService userManagerService,
            IMapper mapper)
        {
            _logger = logger;
            _userValidationService = userValidationService;
            _userManagerService = userManagerService;
            _mapper = mapper;
        }

        /// <summary>
        /// kiểm tra thông tin đăng ký của người dùng (email, username, phone) có hợp lệ và chưa được sử dụng hay không
        /// </summary>
        /// <param name="userInfor">chuỗi thông tin (email/username/phone)</param>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        public async Task<UserValidation> CheckInforUserRegisterAsync(string userInfor)
        {
            if (string.IsNullOrEmpty(userInfor)) throw new BadRequestException("Thông tin không hợp lệ.");
            await _userValidationService.EnsureEmailUniqueAsync(userInfor);
            await _userValidationService.EnsureUserNameUniqueAsync(userInfor);
            await _userValidationService.EnsurePhoneNumberUniqueAsync(userInfor);
            return new UserValidation { IsAvailable = true, Message = "Thông tin hợp lệ" };
        }

        /// <summary>
        /// đăng ký người dùng mới với thông tin quyền basic
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        public async Task<bool> RegisterAsync(UserRegisterRequest request)
        {
            if (request == null) throw new BadRequestException("Thông tin đang ký không hợp lệ.");
            var userRegister = _mapper.Map<ApplicationUser>(request);
            var result = await _userManagerService.CreateAsync(userRegister, request.Password, RoleType.Basic.ToRoleString());

            return result;

        }
    }
}
