using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace q.ResultFilterDemo.Models
{
    public class CustomResultFilterAsync : IAsyncResultFilter
    {
        private Stopwatch? _timer;

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            // Initialize and start the timer
            _timer = Stopwatch.StartNew();

            // Add a custom header before executing the result
            context.HttpContext.Response.Headers.Append("X-Pre-Execute", "Header set before execution");

            // Example: Modify the result based on authorization (dummy condition here)
            if (context.HttpContext.Request.Query.ContainsKey("admin") && context.Result is ViewResult viewResult)
            {
                context.Result = new ViewResult
                {
                    ViewName = "AdminView",
                    ViewData = viewResult.ViewData,
                    TempData = viewResult.TempData
                };
            }

            // Execute the result as planned
            var executedContext = await next();

            // Stop the timer after the result is executed
            _timer.Stop();
            var actionName = context.ActionDescriptor.DisplayName;
            var executionTime = _timer.ElapsedMilliseconds;
            var resultType = executedContext.Result.GetType().Name;

            // Log details about the action execution
            Debug.WriteLine($"Action '{actionName}' executed in {executionTime} ms, resulting in {resultType}");
        }
    }
}