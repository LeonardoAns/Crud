using Crud.Application.AutoMapping;
using Crud.Domain.Repositories.Category;
using Crud.Domain.Repositories.Product;
using Crud.Domain.Repositories.UnitOfWork;
using Crud.Infrastructure.DbContext;
using Crud.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Crud.Infrastructure;

public static class DependencyInjectionExtension {

    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration){
        AddDbContext(services,configuration);
        AddRepositories(services);
        AddAutoMapper(services);
    }

    private static void AddRepositories(IServiceCollection services){
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
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