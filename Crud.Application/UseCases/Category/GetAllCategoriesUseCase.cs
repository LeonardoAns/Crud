using AutoMapper;
using Communication.Response.Category;
using Crud.Application.IUseCases;
using Crud.Domain.Entities;
using Crud.Domain.Repositories.Category;
using Crud.Domain.Repositories.UnitOfWork;

namespace Crud.Application.UseCases;

public class GetAllCategoriesUseCase : IGetAllCategoriesUseCase{
    
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllCategoriesUseCase(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork,IMapper mapper){
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<CategoryResponseJson>> Execute(){
        var categories = await _categoryRepository.GetAllAsync();
        return categories.Select(category => _mapper.Map<CategoryResponseJson>(category)).ToList();
    }
}