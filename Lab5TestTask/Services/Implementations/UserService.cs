using Lab5TestTask.Data;
using Lab5TestTask.Models;
using Lab5TestTask.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lab5TestTask.Services.Implementations;

/// <summary>
/// UserService implementation.
/// Implement methods here.
/// </summary>
public class UserService : IUserService
{
    private readonly ApplicationDbContext _dbContext;

    public UserService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<User> GetUserAsync()
    {
        var User = await _dbContext.Users.OrderByDescending(x=>x.Sessions.Count).FirstOrDefaultAsync();
        return User;
        throw new NotImplementedException();
    }

    public async Task<List<User>> GetUsersAsync()
    {
        try
        {
            var UsersLIst= await _dbContext.Users.Where(x=>x.Sessions.Any(x=>x.DeviceType==Enums.DeviceType.Mobile)).ToListAsync();
            return UsersLIst;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        throw new NotImplementedException();
    }
}
