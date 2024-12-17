using Crud.Application.AutoMapping;
using Crud.Domain.Repositories.Category;
using Crud.Domain.Repositories.Product;
using Crud.Domain.Repositories.UnitOfWork;
using Crud.Domain.Repositories.User;
using Crud.Domain.Security;
using Crud.Infrastructure.DbContext;
using Crud.Infrastructure.Repositories;
using Crud.Infrastructure.Security;
using Crud.Infrastructure.Security.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Crud.Infrastructure;

public static class DependencyInjectionExtension {

    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration){
        AddDbContext(services,configuration);
        AddRepositories(services);
        AddAutoMapper(services);
        AddToken(services,configuration);
    }

    private static void AddToken(IServiceCollection services, IConfiguration configuration){
        var expirationTimeMinutes = configuration.GetValue<uint>("Settings:Jwt:ExpiresMinutes");
        var signingKey = configuration.GetValue<string>("Settings:Jwt:SigningKey");

        services.AddScoped<IAccessTokenGenerator>(config => new AccessTokenGenerator(expirationTimeMinutes, signingKey!));
    }
    
    private static void AddRepositories(IServiceCollection services){
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        services.AddScoped<IPasswordEncripter, BCryptConfig>();
        services.AddScoped<ITokenProvider, TokenProvider>();
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration){
        var connectionString = configuration.GetConnectionString("Connection");
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 40));

        services.AddDbContext<CrudDbContext>(config => config.UseMySql(connectionString, serverVersion));
    }
    
    private static void AddAutoMapper(IServiceCollection services){
        services.AddAutoMapper(typeof(AutoMappingConfig));

    }
}