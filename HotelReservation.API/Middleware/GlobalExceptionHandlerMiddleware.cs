using HotelReservation.Application.Result;
using HotelReservation.Domain.Exceptions;
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

                if (ex.GetType()==(typeof(FluentValidation.ValidationException)))
                {
                    var validationException = ex as FluentValidation.ValidationException;

                    var validationErrors = validationException.Errors.Select(x => x.ErrorMessage).ToList();

                    ErrorResult errorResult = new ErrorResult(validationErrors);

                    httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                    httpContext.Response.ContentType = "application/json";

                   await httpContext.Response.WriteAsJsonAsync(ApiResult<bool>.FailureResult(errorResult,HttpStatusCode.BadRequest),new JsonSerializerOptions() { PropertyNamingPolicy=null});


                }

                else if (ex.GetType()==typeof(InvalidUserCridentialsException))
                {
                    
                    ErrorResult errorResult = new ErrorResult(errors);

                    httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

                    httpContext.Response.ContentType = "application/json";

                    await httpContext.Response.WriteAsJsonAsync(ApiResult<bool>.FailureResult(errorResult, HttpStatusCode.Unauthorized), new JsonSerializerOptions() { PropertyNamingPolicy = null });
                }
                else if (ex.GetType() == typeof(UserNotFoundException))
                {

                    ErrorResult errorResult = new ErrorResult(errors);

                    httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;

                    httpContext.Response.ContentType = "application/json";

                    await httpContext.Response.WriteAsJsonAsync(ApiResult<bool>.FailureResult(errorResult, HttpStatusCode.NotFound), new JsonSerializerOptions() { PropertyNamingPolicy = null });
                }

                else
                {
                    ErrorResult errorResult = new ErrorResult(errors);

                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                    httpContext.Response.ContentType = "application/json";

                    await httpContext.Response.WriteAsJsonAsync(ApiResult<bool>.FailureResult(errorResult, HttpStatusCode.InternalServerError), new JsonSerializerOptions() { PropertyNamingPolicy = null });
                }
               
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
