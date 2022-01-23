using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Data
{
    public class TransactionDbContext : DbContext
    {
        public TransactionDbContext(DbContextOptions<TransactionDbContext> options) : base(options)
        {
            
        }

        public virtual DbSet<User> Users { get; set;}

        // protected override void OnModelCreating(ModelBuilder builder1)
        // {
        //     builder1.Entity<User>().HasData
        //     (
        //         new User
        //         {
                    
        //         }

        //     );
            
        // }
    }
}