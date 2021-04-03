using System;
using Microsoft.AspNetCore.Mvc;
using MyFirstAspNetCoreApp.Filters;

namespace MyFirstAspNetCoreApp.Controllers
{
    //register filter locally
    //[AppHeaderActionFilter]
    public class InfoController : Controller
    {
        //can also be used over an action instead of over the controller
        //[AppHeaderActionFilter]
        public IActionResult Time()
        {
            return this.Content(DateTime.Now.ToLongTimeString());
        }

        public IActionResult Date()
        {
            return this.Content(DateTime.Now.ToLongDateString());
        }
    }
}
