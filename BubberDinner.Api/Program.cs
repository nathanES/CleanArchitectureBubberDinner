using BubberDinner.Api;
using BubberDinner.Application;
using BubberDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
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