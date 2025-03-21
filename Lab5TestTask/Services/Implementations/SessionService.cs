using Lab5TestTask.Data;
using Lab5TestTask.Models;
using Lab5TestTask.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lab5TestTask.Services.Implementations;

/// <summary>
/// SessionService implementation.
/// Implement methods here.
/// </summary>
public class SessionService : ISessionService
{
    private readonly ApplicationDbContext _dbContext;

    public SessionService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Session> GetSessionAsync()
    {
        try
        {
            var earleRecord = await _dbContext.Sessions.OrderBy(s=>s.EndedAtUTC).FirstOrDefaultAsync();
            if (earleRecord == null) 
            {
                throw new InvalidOperationException("No record found in data base");
            }
            return earleRecord;
        }
        catch (Exception ex) 
        {
            throw ex;    
        }
        //throw new NotImplementedException();
    }

    public async Task<List<Session>> GetSessionsAsync()
    {
        try
        {
            var ActiveServices = await _dbContext.Sessions
                .Where(x=>x.User.Status==Enums.UserStatus.Active && x.EndedAtUTC<new DateTime(2025,1,1)).ToListAsync();
            return ActiveServices;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        throw new NotImplementedException();
    }
}
