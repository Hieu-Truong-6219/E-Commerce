namespace UserMicroService.Application;

public interface IPasswordHashService
{
    public string Hash(string rawPassword);
    public bool VerifyHash(string hashedPassword, string rawPassword);
}
