﻿using Application.Wrappers;
using System.Net;
using System.Text.Json;

namespace WebAPI.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;

        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);   
            }catch
            (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new Response<string> { Succeeded = false, Message = error.Message };
                switch (error)
                {
                    case Application.Exceptions.ApiExceptions e:
                        //custom application error
                        response.StatusCode=(int)HttpStatusCode.BadRequest;
                        break; 
                    case Application.Exceptions.ValidationException e:
                        //validation error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Errors = e.Errors;
                        break;
                    case KeyNotFoundException e:
                        //not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        //unhandle error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result= JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);
            }
        }
    }

}
