using GTS.TodoApp.Infrastructure;
using GTS.TodoApp.Core.Application;
using GTS.TodoApp.Shared.Helpers;
using GTS.TodoApp.Shared;
using Microsoft.AspNetCore.Mvc;
namespace GTS.TodoApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                            .ConfigureApiBehaviorOptions(option =>
                            {
                                option.InvalidModelStateResponseFactory = actionContext =>
                                {
                                    // ModelState is a Dic [KeyValuePear]
                                    // Key Name Of Param
                                    var errors = actionContext.ModelState.Where(param => param.Value!.Errors.Count > 0)
                                                   .SelectMany(param => param.Value!.Errors)
                                                   .Select(E => E.ErrorMessage)
                                                   .ToList();

                                    var result = new ValidationErrorHandling() { StatusCode = 400, Errors = errors };
                                    return new BadRequestObjectResult(result);
                                };
                            }
                                
                             )
                            .AddApplicationPart(typeof(Controllers.AssemblyInformation).Assembly);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region AddCustomServices

            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddApplicationServices();

            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
