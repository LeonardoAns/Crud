using System.ComponentModel.Design;
using Communication.Requests.User;
using Crud.Application.AutoMapping;
using Crud.Application.IUseCases;
using Crud.Application.IUseCases.Product;
using Crud.Application.IUseCases.User;
using Crud.Application.UseCases;
using Crud.Application.UseCases.Product;
using Crud.Application.UseCases.User;
using Microsoft.Extensions.DependencyInjection;

namespace Crud.Application;

public static class DependencyInjectionExtension {

    public static void AddApplication(this IServiceCollection services){
        AddUseCases(services);
        AddAutoMapper(services);
    }

    private static void AddUseCases(IServiceCollection services){
        //Categories
        services.AddScoped<IRegisterCategoryUseCase, RegisterCategoryUseCase>();
        services.AddScoped<IGetAllCategoriesUseCase, GetAllCategoriesUseCase>();
        services.AddScoped<IDeleteCategoryUseCase, DeleteCategoryUseCase>();
        services.AddScoped<IGetCategoryByIdUseCase, GetCategoryByIdUseCase>();
        services.AddScoped<IUpdateCategoryUseCase, UpdateCategoryUseCase>();
        
        //Products
        services.AddScoped<IRegisterProductUseCase, RegisterProductUseCase>();
        services.AddScoped<IGetAllProductUseCase, GetAllProductUseCase>();
        services.AddScoped<IDeleteProductUseCase, DeleteProductUseCase>();
        services.AddScoped<IGetProductByIdUseCase, GetProductByIdUseCase>();
        services.AddScoped<IUpdateProductUseCase, UpdateProductUseCase>();
        services.AddScoped<ILogedUserUseCase, LogedUserUseCase>();
        
        //Users
        services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
        services.AddScoped<ILoginUserUserCase, LoginUserUseCase>();
    }

    private static void AddAutoMapper(IServiceCollection services){
        services.AddAutoMapper(typeof(AutoMappingConfig));
    }
}