using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.Interfaces.Features;
using UserService.Application.Models.Dtos.User.Identity;

namespace UserService.WebApi.Controllers
{
    [Route("api/v1/tai-khoan")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountService _accountService;
        public AccountController(ILogger<AccountController> logger, IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }

        /// <summary>
        /// Check thông tin đăng ký người dùng mới (email, số điện thoại, tên đăng nhập) đã tồn tại hay chưa.
        /// </summary>
        /// <param name="userInfor">chuỗi ký tự người dùng nhập email/sdt/username</param>
        /// <response code="200">Thông tin có thể đăng ký.</response>
        /// <response code="409">Thông tin đăng ký tồn tại.</response>
        /// <returns>bool true/false</returns>
        [HttpGet("kiem-tra-thong-tin-dang-ky")]
        public async Task<IActionResult> CheckInforUserRegisterAsync([FromQuery] string userInfor)
        {
            _logger.LogInformation($"Kiểm tra thông tin đăng ký {nameof(CheckInforUserRegisterAsync)}: {userInfor}");
            var result = await _accountService.CheckInforUserRegisterAsync(userInfor);
            _logger.LogInformation($"Kết quả kiểm tra thông tin đăng ký {nameof(CheckInforUserRegisterAsync)}: {result}");
            return Ok(result);
        }

        /// <summary>
        /// Đăng ký thông tin người dùng mới.
        /// </summary>
        /// <returns>kết quả đăng ký thành công true/false.</returns>
        /// <response code="200">Đăng ký thành công.</response>
        /// <response code="409">Thông tin đăng ký tồn tại.</response>
        [ProducesResponseType(typeof(IEnumerable<UserRegisterRequest>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("dang-ky")]
        public async Task<IActionResult> RegisterAsync([FromBody] UserRegisterRequest request)
        {
            var result = await _accountService.RegisterAsync(request);
            return Ok(result);
        }
    }
}
