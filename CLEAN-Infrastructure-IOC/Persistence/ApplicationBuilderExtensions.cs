using Microsoft.AspNetCore.Builder;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;

namespace CLEAN_Infrastructure_IOC.Persistence
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseFluentValidationExceptionHandler(this IApplicationBuilder app)
        {
            string filePath = Environment.CurrentDirectory + "/ErrorLogs.txt";
            app.UseExceptionHandler(x => {
                x.Run(async context => {
                    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = errorFeature.Error;

                    if (!(exception is ValidationException validationException))
                    {
                        CreateFile(filePath);
                        WriteOnFile(filePath, exception.Message);
                        throw exception;
                    }

                    var errors = validationException.Errors.Select(err => new {
                        err.PropertyName,
                        err.ErrorMessage
                    });

                    var errorText = JsonSerializer.Serialize(errors);
                    context.Response.StatusCode = 400;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync("gesjfhesjgesfbeshgesfesgesfes", Encoding.UTF8);
                });
            });
        }

        private static void CreateFile(string filePath)
        {
            if (!File.Exists(filePath))
                File.Create(filePath);
        }

        private static void WriteOnFile(string filePath, string message)
        {
            TextWriter tsw = new StreamWriter(filePath, true);
            tsw.WriteLine(DateTime.Now.ToString() + " - " + message);
            tsw.Close();
        }
    }
}
