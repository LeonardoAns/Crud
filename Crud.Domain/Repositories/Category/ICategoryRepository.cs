namespace Crud.Domain.Repositories.Category;
using Entities;

public interface ICategoryRepository {
    Task AddAsync(Category category);
    Task<List<Category>> GetAllAsync();
    Task DeleteAsync(Category category);
    Task<Category?> FindByIdAsync(long id);

    Task UpdateAsync(long id, Category request);
}