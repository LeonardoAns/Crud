using AutoMapper;
using Communication.Requests.Category;
using Communication.Requests.Product;
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
    }

    private void EntityToResponse()
    {
        CreateMap<Category, CategoryResponseJson>();
        CreateMap<Product, ProductResponseJson>();
    }
}