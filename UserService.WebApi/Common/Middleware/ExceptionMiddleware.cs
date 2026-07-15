using UserService.Application.Common.Models;

namespace UserService.WebApi.Common.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            try { await _next(context); }
            catch (BaseException ex)
            {
                context.Response.StatusCode = ex.StatusCode;
                await context.Response.WriteAsJsonAsync(ApiResponse<object>.FailureResult(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(ApiResponse<object>.FailureResult("Lỗi hệ thống nội bộ."));
            }
        }
    }
}
