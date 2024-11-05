using System.Reflection;
using BubberDinner.Application.Authentication.Commands.Register;
using BubberDinner.Application.Authentication.Common;
using BubberDinner.Application.Common.Behaviors;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BubberDinner.Application;

public static class DependencyInjection
{
   public static IServiceCollection AddApplication(this IServiceCollection services)
   {
       services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
       services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
       services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
       return services;
   }
}