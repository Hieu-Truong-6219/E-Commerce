using Microsoft.EntityFrameworkCore;
using User_service.Application;
using User_service.Domain;

namespace User_service.Infrastructure;

public class UserRepository(UserDbContext context) : IUserRepository
{
    private readonly UserDbContext _context = context;

    public async Task<UserInfo> CreateUserAsync(UserInfo info)
    {
        var result = _context.Users.Add(info);

        await _context.SaveChangesAsync();

        return result.Entity;
    }

    public async Task<List<UserInfo>> GetAllUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<UserInfo?> GetUserInfoAsync(string uuid)
    {
        return await _context.Users.FirstOrDefaultAsync(user => user.Uuid == uuid);
    }

    public async Task<UserInfo> UpdateUserAsync(string uuid, UserInfo info)
    {
        // Throwing error since user should have been checked before hand.
        var user =
            await GetUserInfoAsync(uuid) ?? throw new Exception("Invalid User uuid provided");

        user.Username = info.Username;
        user.Password = info.Password;

        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<UserInfo> DeleteUserAsync(string uuid)
    {
        var user =
            await GetUserInfoAsync(uuid) ?? throw new Exception("Invalid User uuid provided");

        _context.Remove(user);

        await _context.SaveChangesAsync();

        return user;
    }
}
