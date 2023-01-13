using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MergeMe.Model
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Recruiter> Recruiters { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<StackFromDeveloper> DeveloperStacks { get; set; }
        public DbSet<StackFromRecruiter> RecruiterStacks { get; set; }
        public DbSet<Stacks> Stacks { get; set; }
        public DbSet<Match> matches { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Developer>().Property(p => p.FirstName).IsRequired();
            builder.Entity<Developer>().Property(p => p.LastName).IsRequired();
            builder.Entity<Developer>().Property(p => p.email).IsRequired();
            builder.Entity<Developer>().Property(p => p.password).IsRequired();
            builder.Entity<Developer>().Property(p => p.BirthDate).IsRequired();

            builder.Entity<Recruiter>().Property(p => p.FirstName).IsRequired();
            builder.Entity<Recruiter>().Property(p => p.LastName).IsRequired();
            builder.Entity<Recruiter>().Property(p => p.email).IsRequired();
            builder.Entity<Recruiter>().Property(p => p.password).IsRequired();
            builder.Entity<Recruiter>().Property(p => p.BirthDate).IsRequired();

        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
        {
            configuration.Properties<string>().HaveMaxLength(100);
        }
    }
}
