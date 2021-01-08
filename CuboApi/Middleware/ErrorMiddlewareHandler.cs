using System;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using CuboCore.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CuboApi.Middleware {

    public class ErrorMiddlewareHandler {

        /*------------------------ FIELDS REGION ------------------------*/
        private readonly RequestDelegate _next;

        /*------------------------ METHODS REGION ------------------------*/
        public ErrorMiddlewareHandler(RequestDelegate next) {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext) {
            try {
                await _next(httpContext);
            } catch (Exception exception) {
                await HandleErrorAsync(httpContext, exception);
            }
        }

        private static Task HandleErrorAsync(HttpContext httpContext, Exception exception) {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;

            switch (exception) {
                case NotFoundException e: {
                    statusCode = HttpStatusCode.BadRequest;
                    break;
                }
                case AlreadyExistsException e: {
                    statusCode = HttpStatusCode.BadRequest;
                    break;
                }
                case ArgumentException e: {
                    statusCode = HttpStatusCode.NotAcceptable;
                    break;
                }
            }

            httpContext.Response.ContentType = MediaTypeNames.Application.Json;
            httpContext.Response.StatusCode = (int)statusCode;

            return httpContext.Response.WriteAsync(
                JsonConvert.SerializeObject(new { message = exception.Message })
            );
        }

    }

}
