using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Application.Common.Models
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; } 
        public string Message { get; set; } = "Có lỗi xảy ra.";
        public List<string> Errors { get; set; } = new();

        public static ApiResponse<T> SuccessResult(T? data, string message = "Thành công.")
            => new() { Success = true, Data = data, Message = message };

        public static ApiResponse<T> FailureResult(string message, List<string>? errors = null)
            => new() { Success = false, Message = message, Errors = errors ?? new() };
    }
}
