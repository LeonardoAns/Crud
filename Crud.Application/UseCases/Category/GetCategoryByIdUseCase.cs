using AutoMapper;
using Communication.Response.Category;
using Crud.Application.IUseCases;
using Crud.Domain.Entities;
using Crud.Domain.Repositories.Category;
using Crud.Exception.ExceptionModel;

namespace Crud.Application.UseCases;

public class GetCategoryByIdUseCase : IGetCategoryByIdUseCase {

    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetCategoryByIdUseCase(ICategoryRepository categoryRepository, IMapper mapper){
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CategoryResponseJson> Execute(long id){
        Category category = await _categoryRepository.FindByIdAsync(id)??
                            throw new NotFoundException("Category Not Founed");
        return _mapper.Map<CategoryResponseJson>(category);
    }
}