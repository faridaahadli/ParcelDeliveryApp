using Auth.ApiResponse;
using Auth.Data.Exceptions;
using System;
using System.Net;
using System.Text.Json;

namespace Auth.API.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;


        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;

        }


        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }


        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {


            if (ex is not CustomException && ex.InnerException != null)
            {
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }
            }

            string result = JsonSerializer.Serialize(
                new ApiResponse<string>(ex.Message, SetErrorCode(ex)),
                 new JsonSerializerOptions()
                 {
                     PropertyNameCaseInsensitive = true,
                 });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = SetErrorCode(ex);

            return context.Response.WriteAsync(result);
        }

        private int SetErrorCode(Exception ex)
        {
            switch (ex)
            {
                case CustomException e:
                    return (int)e.StatusCode;               
                default:
                    return (int)HttpStatusCode.Unauthorized;
            }
        }

    }
}
