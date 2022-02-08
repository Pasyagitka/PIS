using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HTTPHandlers
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var routeBuilder = new RouteBuilder(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseHttpsRedirection();

            routeBuilder.MapGet("zei",
                async context => {
                    context.Response.ContentType = "text/plain; charset=utf-8";
                    var ParmA = context.Request.Query["ParmA"];
                    var ParmB = context.Request.Query["ParmB"];
                    await context.Response.WriteAsync($"GET-Http-ZEI:ParmA = {ParmA},ParmB = {ParmB}");
                });
            
            routeBuilder.MapPost("zei",
                async context => {
                    context.Response.ContentType = "text/plain; charset=utf-8";
                    var ParmA = context.Request.Form["ParmA"];
                    var ParmB = context.Request.Form["ParmB"];
                    await context.Response.WriteAsync($"POST-Http-ZEI:ParmA = {ParmA},ParmB = {ParmB}"); 
                });
            
            routeBuilder.MapPut("zei",
                async context => {
                    context.Response.ContentType = "text/plain; charset=utf-8";
                    var ParmA = context.Request.Form["ParmA"];
                    var ParmB = context.Request.Form["ParmB"];
                    await context.Response.WriteAsync($"PUT-Http-ZEI:ParmA = {ParmA},ParmB = {ParmB}"); 
                });
            
            routeBuilder.MapPost("zei/sum",
                async context => {
                    context.Response.ContentType = "text/plain; charset=utf-8";
                    var X = context.Request.Form["X"];
                    var Y = context.Request.Form["Y"];
                    await context.Response.WriteAsync($"Sum = {Int32.Parse(X)+Int32.Parse(Y)}"); 
                });

            routeBuilder.MapRoute("zei/mul5", async context =>
            {
                if (context.Request.Method == HttpMethods.Get)
                {
                    context.Response.ContentType = "text/html; charset=utf-8";
                    await context.Response.SendFileAsync("html/5.html");
                }
                else if (context.Request.Method == HttpMethods.Post)
                {
                    context.Response.ContentType = "text/html; charset=utf-8";
                    var X = context.Request.Form["X"];
                    var Y = context.Request.Form["Y"];
                    await context.Response.WriteAsync($"Mul = {Int32.Parse(X)*Int32.Parse(Y)}"); 
                }
                //else not found!
            });
            
            routeBuilder.MapRoute("zei/mul6", async context =>
            {
                if (context.Request.Method == HttpMethods.Get)
                {
                    context.Response.ContentType = "text/html; charset=utf-8";
                    await context.Response.SendFileAsync("html/6.html");
                }
                else if (context.Request.Method == HttpMethods.Post)
                {
                    var X = context.Request.Form["X"];
                    var Y = context.Request.Form["Y"];
                    await context.Response.WriteAsync($"Mul = {Int32.Parse(X)*Int32.Parse(Y)}"); 
                }
                //else not found!
            });
            
            app.UseRouter(routeBuilder.Build());

            // app.Run(async context =>
            // {
            //     context.Response.Headers["Content-Type"] = "text/html; charset=utf-8";
            // });
        }
    }
}