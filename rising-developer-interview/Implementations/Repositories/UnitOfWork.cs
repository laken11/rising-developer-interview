using rising_developer_interview.Contracts.Repositories;
using rising_developer_interview.Infrastructure.Context;

namespace rising_developer_interview.Implementations.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}