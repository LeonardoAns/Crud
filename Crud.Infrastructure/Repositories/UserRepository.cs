using Crud.Domain.Entities;
using Crud.Domain.Repositories.User;
using Crud.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Crud.Infrastructure.Repositories;

public class UserRepository : IUserRepository {

    private CrudDbContext _dbContext;

    public UserRepository(CrudDbContext dbContext){
        _dbContext = dbContext;
    }

    public async Task AddAsync(User user){
        await _dbContext.Users.AddAsync(user);
    }

    public async Task<bool> ExistsByEmail(string email){
        return await _dbContext.Users.AnyAsync(user => user.Email.Equals(email));
    }

    public async Task<User?> GetUserByEmail(string email){
        return await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(user => user.Email.Equals(email));

    }
}