using Communication.Requests.Category;
using Communication.Response.Category;

namespace Crud.Domain.Repositories.Category;
using Entities;

public interface ICategoryRepository {
    Task AddAsync(Category category);
    Task<List<Category>> GetAllAsync();
    Task<bool> DeleteAsync(long id);
    Task<Category?> FindByIdAsync(long id);

    Task UpdateAsync(long id, Category request);
}