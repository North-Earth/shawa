using Microsoft.Extensions.DependencyInjection;
using Shawa.Application.Repositories;
using Shawa.Infrastructure.AutoMapperProfiles;
using Shawa.Infrastructure.Entities;

namespace Shawa.Infrastructure;

public static class StartupSetup
{
    public static void AddMongoDbContext(this IServiceCollection services)
    {
        services.AddSingleton<IRestaurantRepository, RestaurantRepository>();
    }
    
    public static void AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DomainToEntity), typeof(EntityToDomain));
    }
}