namespace Crud.Domain.Repositories.Product;

using Entities;

public interface IProductRepository {
    
    Task AddAsync(Product product);
    Task<List<Product>> GetAllAsync();
    Task DeleteAsync(Product product);
    Task<Product?> FindByIdAsync(long id);
    Task UpdateAsync(long id, Product request);

    Task<Category?> GetCategoryByIdAsync(long id);
}