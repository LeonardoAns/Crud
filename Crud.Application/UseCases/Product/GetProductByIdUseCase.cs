using AutoMapper;
using Communication.Response.Response;
using Crud.Application.IUseCases.Product;
using Crud.Domain.Repositories.Product;
using Crud.Domain.Repositories.UnitOfWork;
using Crud.Exception.ExceptionModel;

namespace Crud.Application.UseCases.Product;

public class GetProductByIdUseCase : IGetProductByIdUseCase{
    
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetProductByIdUseCase(IProductRepository productRepository, IMapper mapper, IUnitOfWork unitOfWork){
        _productRepository = productRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<ProductResponseJson> Execute(long id){
        var product = await _productRepository.FindByIdAsync(id) ?? throw new NotFoundException("Product Not Found");
        return _mapper.Map<ProductResponseJson>(product);
    }
}