using BubberDinner.Api.Common.Errors;
using BubberDinner.Api.Filters;
using BubberDinner.Api.Middleware;
using BubberDinner.Application;
using BubberDinner.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

//ErrorHandling Number 3 and 4 are the best approach.
var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
    //ErrorHandling Number 2.
    // builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
    builder.Services.AddControllers();
    //ErrorHandling Number 4. (can be used with the Number 3)
    builder.Services.AddSingleton<ProblemDetailsFactory, BubberDinnerProblemDetailsFactory>();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();
{
    //ErrorHandling Number 1.
    // app.UseMiddleware<ErrorHandlingMiddleware>();
    //ErrorHandling Number 3. (can be used with the Number 3)
    app.UseExceptionHandler("/error");
    app.MapControllers();
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();


    app.Run();
}