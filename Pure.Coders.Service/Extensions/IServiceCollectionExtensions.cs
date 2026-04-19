using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pure.Dal.Coders.Toolbox;
using Pure.Dal.Coders.Toolbox.Repositories;
using Pure.Library.SQLite.Extensions;

namespace Pure.Coders.Service.Extensions;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddSqliteDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSqliteDatabase<DeveloperToolboxContext>(configuration);
        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<CodeFlavourRepository>()
                .AddTransient<LookUpRepository>()
                .AddTransient<CodeObjectMatrixRepository>()
                .AddTransient<ClassSpecificationRepository>()
                .AddTransient<PropertySpecificationRepository>()
                .AddTransient<MethodSpecificationRepository>()
                .AddTransient<ParameterSpecificationRepository>()
                .AddTransient<PropertySpecificationCodeImplementationRepository>();
        return services;
    }
}
