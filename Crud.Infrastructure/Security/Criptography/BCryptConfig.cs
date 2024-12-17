using Crud.Domain.Security;

namespace Crud.Infrastructure.Security;

public class BCryptConfig : IPasswordEncripter{
    public string Encrypt(string password){
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool Verify(string password, string passwordHash) => BCrypt.Net.BCrypt.Verify(password, passwordHash);
}