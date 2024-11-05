using System.Reflection;
using BubberDinner.Application.Authentication.Commands.Register;
using BubberDinner.Application.Authentication.Common;
using BubberDinner.Application.Authentication.Queries.Login;
using BubberDinner.Contracts.Authentication;
using Mapster;
using MapsterMapper;

namespace BubberDinner.Api.Common.Mapping;

//I prefer to have a manual mapping rather to have a mapping library.
//Because you are moving errors from compile time to runtime.
public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        
        config.NewConfig<LoginRequest, LoginQuery>();
        
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Token, src => src.Token)
            .Map(dest => dest, src => src.User);
    }
}
public static class DependancyInjection
{
    public static IServiceCollection AddMappings(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();
        return services;
    }
}