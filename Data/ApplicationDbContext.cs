using JPSEMWebApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JPSEMWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<HouseholdPackage> HouseholdPackages { get; set; }
        public DbSet<BusinessPackage> BusinessPackages { get; set; }
        public DbSet<LtePackage> LtePackages { get; set; }
        public DbSet<Router> Routers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<AirfibrePackage> AirfibrePackages { get; set; }
        public DbSet<ServiceNotice> ServiceNotices { get; set; }

    }
}