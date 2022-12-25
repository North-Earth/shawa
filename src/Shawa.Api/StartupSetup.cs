using Shawa.Api.AutoMapperProfiles;
using Shawa.Infrastructure.Configuration;

namespace Shawa.Api;

public static class StartupSetup
{
    public static void AddAutoMapperDto(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DtoToDomain));
    }
    
    public static WebApplicationBuilder? ConfigureEnvironments(this WebApplicationBuilder? builder)
    {
        // // builder.Services.AddAutoMapper(typeof(DtoToDomain));
        // // builder.Services.Configure<MongoSettings>(builder.Configuration.GetSection(nameof(MongoSettings)));
        //
        // var currentEnvironment= Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        //
        // if(currentEnvironment== "Development")
        // {
        //     var a = builder.Configuration.GetSection(nameof(MongoSettings));
        //     var b = new ConfigurationBuilder();
        //     builder.Services.Configure<MongoSettings>(builder.Configuration.GetSection(nameof(MongoSettings)));
        // }

        return builder;
    }
}