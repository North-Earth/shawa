using Shawa.Api.AutoMapperProfiles;

namespace Shawa.Api;

public static class StartupSetup
{
    public static void AddAutoMapperDto(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DtoToDomain));
    }
}