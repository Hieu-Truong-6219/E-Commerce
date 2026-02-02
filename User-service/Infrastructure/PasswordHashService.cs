using Isopoh.Cryptography.Argon2;
using UserMicroService.Application;
using UserMicroService.Domain;

namespace UserMicroService.Infrastructure;

public class PasswordHashService : IPasswordHashService
{
    public string Hash(string rawPassword)
    {
        return Argon2.Hash(rawPassword);
    }

    public bool VerifyHash(string hashedPassword, string rawPassword)
    {
        return Argon2.Verify(hashedPassword, rawPassword);
    }
}
