using System.Linq.Expressions;
using rising_developer_interview.Entities;

namespace rising_developer_interview.Contracts.Repositories;

public interface IUserRepository
{
    Task CreateAsync(User user);
    Task<User?> GetAsync(Guid id);
    Task<bool> ExistsAsync(Expression<Func<User, bool>> expression);
}