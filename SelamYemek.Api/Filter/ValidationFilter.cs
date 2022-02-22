using SelamYemek.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelamYemek.Api.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(await CreateErrorResponse());
                return;
            }

            await next();
        }

        private async Task<VoidResult> CreateErrorResponse()
        {
            return await Task.FromResult(new VoidResult() { Code = 400, Failed = true, Message = "Bad Request" });
        }
    }
}
