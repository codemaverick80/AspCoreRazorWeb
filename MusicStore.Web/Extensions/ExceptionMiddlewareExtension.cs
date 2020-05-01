﻿using System;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using MusicStore.Web.CustomMiddlewares;
using MusicStore.Web.Dtos;

namespace MusicStore.Web.Extensions
{
    public static class ExceptionMiddlewareExtension
    {

        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {

            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature != null)
                    {
                        await context.Response.WriteAsync(new ErrorDetails
                        {
                            StatusCode=context.Response.StatusCode,
                            Message="Internal Server Error"
                        }.ToString());
                    }
                });
            });
        }


        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {

            app.UseMiddleware<ExceptionMiddleware>();

        }




    }
}
