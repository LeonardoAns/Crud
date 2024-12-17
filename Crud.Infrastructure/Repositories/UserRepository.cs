using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Crud.Domain.Entities;
using Crud.Domain.Repositories.User;
using Crud.Infrastructure.DbContext;
using Crud.Infrastructure.Security;
using Microsoft.EntityFrameworkCore;

namespace Crud.Infrastructure.Repositories;

public class UserRepository : IUserRepository {

    private CrudDbContext _dbContext;
    private readonly ITokenProvider _tokenProvider;

    public UserRepository(CrudDbContext dbContext, ITokenProvider tokenProvider){
        _dbContext = dbContext;
        _tokenProvider = tokenProvider;
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

    public async Task<User?> FindById(long id){
        return await _dbContext.Users.FindAsync(id);
    }

    public async Task<User?> GetByIdentifier(){
        string token = _tokenProvider.TokenOnRequest();
        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtSecurityToken = tokenHandler.ReadJwtToken(token);
        var identifier = jwtSecurityToken.Claims.First(claim => claim.Type == ClaimTypes.Sid).Value;

        return await _dbContext.Users.AsNoTracking().FirstAsync(user => user.Identifier == Guid.Parse(identifier));
    }
}