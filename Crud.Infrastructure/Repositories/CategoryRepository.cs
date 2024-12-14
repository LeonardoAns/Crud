using AutoMapper;
using Communication.Requests.Category;
using Communication.Response.Category;
using Crud.Domain.Entities;
using Crud.Domain.Repositories.Category;
using Crud.Exception.ExceptionModel;
using Crud.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Crud.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository {

    private CrudDbContext _dbContext;
    private readonly IMapper _mapper;

    public CategoryRepository(CrudDbContext dbContext,IMapper mapper){
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task AddAsync(Category category){
        await _dbContext.Categories.AddAsync(category);
    }

    public async Task<List<Category>> GetAllAsync(){ 
        return await _dbContext.Categories.ToListAsync();

    }

    public async Task<bool> DeleteAsync(long id){
        Category? category = await _dbContext.Categories.FindAsync(id);

        if (category != null){
            _dbContext.Categories.Remove(category);
            return true;
        }

        return false;
    }

    public async Task<Category> FindByIdAsync(long id)
    {
        var category = await _dbContext.Categories.FindAsync(id);
        if (category is null)
        {
            throw new NotFoundException("Categoria não encontrada.");
        }
        return category;
    }


    public async Task UpdateAsync(long id, Category request){
        var category = await FindByIdAsync(id);

        if (category is null){
            throw new NotFoundException("Category Not Found");
        }
        
        
    }
}