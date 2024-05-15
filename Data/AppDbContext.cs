using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;
using UsersInsurancePolicies.Models;

namespace UsersInsurancePolicies.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<InsurancePolicies> InsurancePolicies { get; set; }
    }
}
