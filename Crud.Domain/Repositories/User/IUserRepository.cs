namespace Crud.Domain.Repositories.User;
using Entities;

public interface IUserRepository {
    Task AddAsync(User user);
    Task<bool> ExistsByEmail(string email);
    Task<User?> GetUserByEmail(string email);
}