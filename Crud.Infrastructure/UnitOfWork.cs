using Crud.Domain.Repositories.UnitOfWork;
using Crud.Infrastructure.DbContext;

namespace Crud.Infrastructure.UnitOfWork;

internal class UnitOfWork : IUnitOfWork {

    private CrudDbContext _dbContext;

    public UnitOfWork(CrudDbContext dbContext){
        _dbContext = dbContext;
    }

    public async Task Commit(){
        await _dbContext.SaveChangesAsync();
    }
}