using AutoMapper;
using Communication.Requests.Category;
using Communication.Requests.Product;
using Communication.Requests.User;
using Communication.Response.Category;
using Communication.Response.Response;
using Crud.Domain.Entities;

namespace Crud.Application.AutoMapping;

public class AutoMappingConfig : Profile
{
    public AutoMappingConfig()
    {
        RequestToEntity();
        EntityToResponse();
    }

    private void RequestToEntity()
    {
        CreateMap<CategoryRequestJson, Category>();
        CreateMap<ProductRequestJson, Product>()
            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId));
        CreateMap<RegisterUserRequestJson, User>()
            .ForMember(dest => dest.Password, config => config.Ignore());
    }

    private void EntityToResponse()
    {
        CreateMap<Category, CategoryResponseJson>();
        CreateMap<Product, ProductResponseJson>();
    }
}