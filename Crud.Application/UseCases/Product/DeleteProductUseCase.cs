using Crud.Application.IUseCases.Product;
using Crud.Domain.Repositories.Category;
using Crud.Domain.Repositories.Product;
using Crud.Domain.Repositories.UnitOfWork;
using Crud.Exception.ExceptionModel;

namespace Crud.Application.UseCases.Product;

public class DeleteProductUseCase : IDeleteProductUseCase{
    
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductUseCase(IProductRepository productRepository, IUnitOfWork unitOfWork){
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(long id){
        var product = await _productRepository.FindByIdAsync(id) ?? throw new NotFoundException("Product Not Found");
        await _productRepository.DeleteAsync(product);
        await _unitOfWork.Commit();
    }
}