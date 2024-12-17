using Crud.Domain.Entities;

namespace Crud.Infrastructure.Security;

public interface IAccessTokenGenerator {
    string GenerateToken(User user);
}