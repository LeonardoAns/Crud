using AutoMapper;
using Crud.Domain.Entities;
using Crud.Domain.Repositories.Product;
using Crud.Exception.ExceptionModel;
using Crud.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Crud.Infrastructure.Repositories;

public class ProductRepository : IProductRepository {

    private CrudDbContext _dbContext;

    public ProductRepository(CrudDbContext dbContext){
        _dbContext = dbContext;
    }

    public async Task AddAsync(Product product){
        await _dbContext.Products.AddAsync(product);
    }

    public async Task<List<Product>> GetAllAsync(){
        return await _dbContext.Products.AsNoTracking().ToListAsync();
    }

    public async Task DeleteAsync(Product product){
        _dbContext.Products.Remove(product);
    }

    public async Task<Product?> FindByIdAsync(long id){
        return await _dbContext.Products.FindAsync(id);
                
    }

    public async Task UpdateAsync(long id, Product request){
        _dbContext.Products.Update(request);
    }

    public async Task<Category?> GetCategoryByIdAsync(long categoryId) {
        return await _dbContext.Categories.FindAsync(categoryId); 
    }
}