using AutoMapper;
using Communication.Response.Response;
using Crud.Application.IUseCases.Product;
using Crud.Domain.Repositories.Product;
using Crud.Domain.Repositories.UnitOfWork;

namespace Crud.Application.UseCases.Product;

public class GetAllProductUseCase : IGetAllProductUseCase{
    
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllProductUseCase(IProductRepository productRepository, IMapper mapper, IUnitOfWork unitOfWork){
        _productRepository = productRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<List<ProductResponseJson>> Execute(){
        var products = await _productRepository.GetAllAsync();
        return products.Select(product => 
                _mapper.Map<ProductResponseJson>(product))
                .ToList();
    }
}