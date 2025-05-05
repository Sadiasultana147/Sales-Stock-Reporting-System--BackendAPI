using Microsoft.EntityFrameworkCore;
using SSRS.Domain;
using SSRS.Domain.Entities;

namespace SSRS.Infrastructure.Persistance.Context
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Products> Products { get; set; }
        public DbSet<SalesEntity> Sales { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
