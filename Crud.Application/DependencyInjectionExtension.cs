using System.ComponentModel.Design;
using Crud.Application.AutoMapping;
using Crud.Application.IUseCases;
using Crud.Application.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace Crud.Application;

public static class DependencyInjectionExtension {

    public static void AddApplication(this IServiceCollection services){
        AddUseCases(services);
        AddAutoMapper(services);
    }

    private static void AddUseCases(IServiceCollection services){
        services.AddScoped<IRegisterCategoryUseCase, RegisterCategoryUseCase>();
        services.AddScoped<IGetAllCategoriesUseCase, GetAllCategoriesUseCase>();
        services.AddScoped<IDeleteCategoryUseCase, DeleteCategoryUseCase>();
        services.AddScoped<IGetCategoryByIdUseCase, GetCategoryByIdUseCase>();
        services.AddScoped<IUpdateCategoryUseCase, UpdateCategoryUseCase>();
    }

    private static void AddAutoMapper(IServiceCollection services){
        services.AddAutoMapper(typeof(AutoMappingConfig));

    }
}