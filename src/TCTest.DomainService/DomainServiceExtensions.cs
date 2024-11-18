using Microsoft.Extensions.DependencyInjection;

namespace TCTest.DomainService;

public static class DomainServiceExtensions
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<IGetUserDS, GetUserDS>();
        services.AddScoped<IGetUserAtDS, GetUserAtDS>();
        services.AddScoped<IAddUserDS, AddUserDS>();
        services.AddScoped<IUpdateUserDS, UpdateUserDS>();
        services.AddScoped<IDeleteUserDS, DeleteUserDS>();
        return services;
    }
}