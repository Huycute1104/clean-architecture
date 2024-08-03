using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    internal class MyDbContext : DbContext 
    {
        public MyDbContext(DbContextOptions<MyDbContext> options): base(options) 
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
