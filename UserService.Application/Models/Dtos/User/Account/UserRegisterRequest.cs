using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Application.Models.Dtos.User.Identity
{
    public class UserRegisterRequest
    {
        [Required(ErrorMessage = "Tên đăng nhập là bắt buộc.")]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = "Email là bắt buộc.")]
        [EmailAddress(ErrorMessage = "Định dạng email không hợp lệ.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Quốc gia là bắt buộc.")]
        public string CountryCode { get; set; } = "VN";

        [Required(ErrorMessage = "Số điện thoại là bắt buộc.")]
        [Phone(ErrorMessage = "Định dạng số điện thoại không hợp lệ.")]
        public string PhoneNumber { get; set; } = null!;

        [Required(ErrorMessage = "Thông tin là bắt buộc.")]
        [RegularExpression(@"^[a-zA-Z0-9 ]*$", ErrorMessage = "Không được chứa ký tự đặc biệt.")]
        public string FullName { get; set; } = null!;

        [Required(ErrorMessage = "Thông tin là bắt buộc.")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Mật khẩu là bắt buộc.")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "Vui lòng xác nhận mật khẩu.")]
        [Compare(nameof(Password), ErrorMessage = "Mật khẩu xác nhận không khớp.")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
