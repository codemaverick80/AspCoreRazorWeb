using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MusicStore.Web.Dtos;

namespace MusicStore.Web.CustomMiddlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;


        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {

            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext);

            }

        }

        private Task HandleExceptionAsync(HttpContext context)
        {

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            context.Response.ContentType = "application/json";

            return context.Response.WriteAsync(new ErrorDetails
            {
                StatusCode = context.Response.StatusCode,
                Message = "Internal Server Error from custom middleware."
            }.ToString());
        }


    }
}
