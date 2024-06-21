using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using rising_developer_interview.Contracts.Repositories;
using rising_developer_interview.Entities;
using rising_developer_interview.Infrastructure.Context;

namespace rising_developer_interview.Implementations.Repositories;

public class UserRepository(ApplicationDbContext applicationDbContext) : IUserRepository
{
    public async Task CreateAsync(User user)
    {
        await applicationDbContext.Users.AddAsync(user);
    }

    public async Task<User?> GetAsync(Guid id)
    {
        return await applicationDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> ExistsAsync(Expression<Func<User, bool>> expression)
    {
        return await applicationDbContext.Users.AnyAsync(expression);
    }
}