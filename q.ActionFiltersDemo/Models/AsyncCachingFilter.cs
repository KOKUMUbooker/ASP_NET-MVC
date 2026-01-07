using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace q.ActionFiltersDemo.Models
{
    public class AsyncCachingFilter :  IAsyncActionFilter
    {
        private readonly IMemoryCache _cache;
        private readonly TimeSpan _expirationTimeSpan;

        public AsyncCachingFilter(IMemoryCache cache, double secondsToCache = 60)
        {
            _cache = cache;
            _expirationTimeSpan = TimeSpan.FromSeconds(secondsToCache);
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var key = $"{context.HttpContext.Request.Path}";
            if (_cache.TryGetValue(key, out IActionResult cachedResult))
            {
                context.Result = cachedResult; // Return cached result
            }
            else
            {
                // Proceed with the action execution
                var executedContext = await next();

                // Cache any IActionResult that is successfully returned
                if (executedContext.Result is ActionResult actionResult)
                {
                    _cache.Set(key, actionResult, _expirationTimeSpan);
                }
            }
        }
    }
}