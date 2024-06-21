namespace rising_developer_interview.Contracts.Repositories;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}