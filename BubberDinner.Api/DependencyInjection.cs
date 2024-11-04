using BubberDinner.Api.Common.Errors;
using BubberDinner.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BubberDinner.Api;

public static class DependencyInjection
{
   public static IServiceCollection AddPresentation(this IServiceCollection services)
   {
       //ErrorHandling Number 2.
       // builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
       services.AddControllers();
       //ErrorHandling Number 4. (can be used with the Number 3)
       services.AddSingleton<ProblemDetailsFactory, BubberDinnerProblemDetailsFactory>();

       services.AddEndpointsApiExplorer();
       services.AddSwaggerGen();
       
       services.AddMappings();
       return services;
   }
}