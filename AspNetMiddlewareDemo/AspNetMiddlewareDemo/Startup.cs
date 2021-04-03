using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetMiddlewareDemo
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //creates new applicationbuilder for a certain address
            //it has its own configure method
            //and it loads the middlewares in its boddy
            app.Map("/home", app => 
            {
                app.Map("/welcome", app => app.UseWelcomePage());
                app.Run(async (req) => 
                {
                    await req.Response.WriteAsync("Other home page");
                });
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("1! ");
                if (DateTime.Now.Second % 2 == 0)
                {
                    await next();
                }
                await context.Response.WriteAsync("6!");
            });
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("2! ");
                await next();
                await context.Response.WriteAsync("5! ");
            });
            //Run says that its the last endpoint executed.
            app.Run(async (request) =>
            {
                await request.Response.WriteAsync("I am the one and only! ");
            });
            //because of Run the endpoints below wont be executed.
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("3! ");
                await context.Response.WriteAsync("4! ");
            });
        }
    }
}
