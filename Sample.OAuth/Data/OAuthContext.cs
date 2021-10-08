using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sample.Entities.Models;

namespace Sample.OAuth.Data
{
    public class OAuthContext : IdentityDbContext<ApplicationUser>
    {
        public OAuthContext(DbContextOptions<OAuthContext> options)
             : base(options)
        {
        }
        public DbSet<ApplicationUser> Accounts { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().HasAlternateKey(u => u.PhoneNumber);
            builder.Entity<ApplicationUser>().HasAlternateKey(u => u.Email);
            base.OnModelCreating(builder);
        }
    }
}
