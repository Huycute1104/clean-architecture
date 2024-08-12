using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    internal class MyDbContext : IdentityDbContext<User,Role,string> 
    {
        public MyDbContext(DbContextOptions<MyDbContext> options): base(options) 
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Role {  get; set; }
    }
}
