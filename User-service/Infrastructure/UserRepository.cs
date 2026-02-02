using UserMicroService.Application;
using UserMicroService.Domain;

namespace UserMicroService.Infrastructure;

public class UserRepository(UserDbContext context) : IUserRepository
{
    private readonly UserDbContext _context = context;

    public async Task<UserInfo> CreateUserAsync(UserInfo info)
    {
        var result = _context.Users.Add(info);

        await _context.SaveChangesAsync();

        return result.Entity;
    }

    public List<UserInfo> GetAllUsers()
    {
        return _context.Users.ToList();
    }

    public UserInfo? GetUserInfo(int id)
    {
        return _context.Users.Find(id);
    }

    public async Task<UserInfo?> UpdateUserAsync(UserInfo info)
    {
        var user = await _context.Users.FindAsync(info.Id);

        if (user == null)
            return null;

        user.Username = info.Username;
        user.Password = info.Password;

        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<UserInfo?> DeleteUserAsync(int id)
    {
        var user = _context.Users.SingleOrDefault(user => user.Id == id);

        if (user == null)
            return null;

        _context.Remove(user);

        await _context.SaveChangesAsync();

        return user;
    }
}
