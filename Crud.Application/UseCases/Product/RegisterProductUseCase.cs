using Crud.Domain.Repositories.UnitOfWork;
using Crud.Exception.ExceptionModel;

namespace Crud.Application.UseCases.Product;

using AutoMapper;
using Communication.Requests.Product;
using Crud.Application.IUseCases.Product;
using Crud.Domain.Repositories.Product;
using Domain.Entities;

public class RegisterProductUseCase : IRegisterProductUseCase {

    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterProductUseCase(IProductRepository productRepository, IMapper mapper, IUnitOfWork unitOfWork){
        _productRepository = productRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(ProductRequestJson request)
    {
        var category = await _productRepository.GetCategoryByIdAsync(request.CategoryId);
        if (category == null)
        {
            throw new NotFoundException("Category not found"); 
        }

        var product = _mapper.Map<Product>(request);
        product.Category = category; 
        
        await _productRepository.AddAsync(product);
        await _unitOfWork.Commit();
    }
}