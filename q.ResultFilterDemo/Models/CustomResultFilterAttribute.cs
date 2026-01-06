using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace q.ResultFilterDemo.Models
{
    public class CustomResultFilterAttribute :  ResultFilterAttribute
    {
        private Stopwatch? _timer;

        public override void OnResultExecuting(ResultExecutingContext context)
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

            base.OnResultExecuting(context);
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            if(_timer == null) return;

            _timer.Stop();
            var actionName = context.ActionDescriptor.DisplayName;
            var executionTime = _timer.ElapsedMilliseconds;
            var resultType = context.Result.GetType().Name;

            // Log details about the action execution
            Debug.WriteLine($"Action '{actionName}' executed in {executionTime} ms, resulting in {resultType}");

            base.OnResultExecuted(context);
        }
    }
}