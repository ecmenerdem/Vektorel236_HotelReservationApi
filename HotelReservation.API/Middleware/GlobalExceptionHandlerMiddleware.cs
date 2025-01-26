using HotelReservation.Application.Result;
using HotelReservation.Domain.Exceptions.User;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace HotelReservation.API.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandlerMiddleware(RequestDelegate next)
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
                List<string> errors = new() { ex.Message };

                httpContext.Response.ContentType = "application/json";

                if (ex.GetType()==(typeof(FluentValidation.ValidationException)))
                {
                    var validationException = ex as FluentValidation.ValidationException;

                    httpContext.Response.StatusCode =httpContext.Response.StatusCode=(int)HttpStatusCode.BadRequest;

                    errors = validationException.Errors.Select(x => x.ErrorMessage).ToList();

                }

                else
                {
                    httpContext.Response.StatusCode = ex.Data["StatusCode"] is not null ? (int)ex.Data["StatusCode"] : (int)HttpStatusCode.InternalServerError;
                   

                }


                ErrorResult errorResult = new ErrorResult(errors);
                await httpContext.Response.WriteAsJsonAsync(ApiResult<object>.FailureResult(errorResult), new JsonSerializerOptions() { PropertyNamingPolicy = null });
            }
            
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class GlobalExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalExceptionHandlerMiddleware>();
        }
    }
}
