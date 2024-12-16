using AutoMapper;
using Crud.Domain.Entities;
using Crud.Domain.Repositories.Product;
using Crud.Exception.ExceptionModel;
using Crud.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Crud.Infrastructure.Repositories;

public class ProductRepository : IProductRepository {

    private CrudDbContext _dbContext;
    private readonly IMapper _mapper;

    public ProductRepository(CrudDbContext dbContext, IMapper mapper){
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task AddAsync(Product product){
        await _dbContext.Products.AddAsync(product);
    }

    public async Task<List<Product>> GetAllAsync(){
        return await _dbContext.Products.ToListAsync();
    }

    public async Task DeleteAsync(Product product){
        _dbContext.Products.Remove(product);
    }

    public async Task<Product?> FindByIdAsync(long id){
        return await _dbContext.Products.FindAsync(id);
                
    }

    public async Task UpdateAsync(long id, Product request){
        var product = await FindByIdAsync(id);
        _dbContext.Products.Update(product);
    }

    public async Task<Category?> GetCategoryByIdAsync(long categoryId) {
        return await _dbContext.Categories.FindAsync(categoryId); 
    }
}