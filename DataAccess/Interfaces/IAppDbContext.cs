using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Interfaces
{
    public interface IAppDbContext
    {
        public DbSet<System_Language> System_Language { get; set; }
        public DbSet<Lookup_Category> Lookup_Category { get; set; }
        public DbSet<System_Lookup> System_Lookup { get; set; }
        public DbSet<Role> Role { get; set; } 
        public DbSet<User> User { get; set; }
        public DbSet<Paint> Paint { get; set; }
        public DbSet<Paint_Detail> Paint_Detail { get; set; }
        public DbSet<Dimension> Dimension { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
