﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Hotel.Filters
{
    public class JsonExceptionFilter : IExceptionFilter
    {
        private readonly IHostingEnvironment _environment;

        public JsonExceptionFilter(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public void OnException(ExceptionContext context)
        {
            var error = new ApiError();

            if (_environment.IsDevelopment())
            {
                error.Message = context.Exception.Message;
                error.Details = context.Exception.StackTrace;
            }
            else
            {
                error.Message = "A server error ocurred.";
                error.Details = context.Exception.Message;
            }


            context.Result = new ObjectResult(error)
            {
                StatusCode = 500
            };
        }
    }
}
