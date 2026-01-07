using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace q.ActionFiltersDemo.Models
{
    public class DataTransformationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is ViewResult viewResult)
            {
                if (viewResult.Model is MyCustomModel model)
                {
                    // Directly modify the model data
                    model.TransformData();
                }
            }

            base.OnActionExecuted(context);
        }
    }
}