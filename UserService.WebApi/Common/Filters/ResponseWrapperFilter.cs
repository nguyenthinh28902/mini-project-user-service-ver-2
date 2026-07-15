using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UserService.Application.Common.Models;

namespace UserService.WebApi.Common.Filters
{
    public class ResponseWrapperFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                context.Result = new BadRequestObjectResult(ApiResponse<object>.FailureResult("Dữ liệu không hợp lệ", errors));
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception == null && context.Result is ObjectResult okResult && okResult.Value is not ApiResponse<object>)
                context.Result = new OkObjectResult(ApiResponse<object>.SuccessResult(okResult.Value));
        }
    }
}
