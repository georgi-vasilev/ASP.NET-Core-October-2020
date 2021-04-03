using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MyFirstAspNetCoreApp.Filters
{
    //ActionFilterAttribute includes IActionFilter and Attribute
    //in that case we override the methods
    //each of those methods has Async version
    public class AddHeaderActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add("X-Info-Action-Name", context.ActionDescriptor.DisplayName);
        }

        //public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        //{
        //    //before
        //    next();
        //    //after
        //}

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            context.HttpContext.Response.Headers.Add("X-Info-Result-Type", context.Result.GetType().Name);
        }
        /* 
            LECTURE NOTES:
        3 ways of registering filter
        1) global - each action will go through the filter
        register happens in startup.cs
        2)locally - it will be executed before and after each action
        in the controller that the filter was registered *check the info controller*
        3)
         */
    }
}
