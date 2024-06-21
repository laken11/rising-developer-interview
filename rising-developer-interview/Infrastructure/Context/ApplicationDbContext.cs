using Microsoft.EntityFrameworkCore;
using rising_developer_interview.Entities;
using rising_developer_interview.Infrastructure.EntityTypeConfigurations;

namespace rising_developer_interview.Infrastructure.Context;

public class ApplicationDbContext : DbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
        base(options)
    {
            
    }
        
    public DbSet<User> Users => Set<User>();
}