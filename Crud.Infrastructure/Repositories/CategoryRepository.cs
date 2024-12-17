using AutoMapper;
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
        return await _dbContext.Categories.AsNoTracking().ToListAsync();
    }

    public async Task DeleteAsync(Category category){
        _dbContext.Categories.Remove(category);
    }

    public async Task<Category> FindByIdAsync(long id){
        return await _dbContext.Categories.FindAsync(id);
        
    }


    public async Task UpdateAsync(long id, Category request){
        _dbContext.Categories.Update(request);
    }
}