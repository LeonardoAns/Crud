using AutoMapper;
using Communication.Requests.Product;
using Crud.Application.IUseCases.Product;
using Crud.Domain.Repositories.Product;
using Crud.Domain.Repositories.UnitOfWork;
using Crud.Exception.ExceptionModel;
using Crud.Exception.ExceptionModel.Validator.Category;

namespace Crud.Application.UseCases.Product;

public class UpdateProductUseCase : IUpdateProductUseCase {

    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateProductUseCase(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper){
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task Execute(long id, ProductRequestJson request){
        var product = await _productRepository.FindByIdAsync(id) ?? throw new NotFoundException("Product Not Found");
        _mapper.Map(request, product);
        await _productRepository.UpdateAsync(id, product);
        await _unitOfWork.Commit();

    }
}