using AutoMapper;
using Communication.Requests.Category;
using Communication.Response.Category;
using Crud.Domain.Entities;

namespace Crud.Application.AutoMapping;

public class AutoMappingConfig : Profile{

    public AutoMappingConfig(){
        RequestToEntity();
        EntityToResponse();
    }
    
    private void RequestToEntity(){
        CreateMap<CategoryRequestJson, Category>();
    }

    private void EntityToResponse(){
        CreateMap<Category, CategoryResponseJson>();
    }

}