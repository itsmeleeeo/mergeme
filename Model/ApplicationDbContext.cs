﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MergeMe.Model
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Developer> Developer { get; set; }
        public DbSet<Recruiter> Recruiter { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<StackFromDeveloper> DeveloperStack { get; set; }
        public DbSet<StackFromRecruiter> RecruiterStack { get; set; }
        public DbSet<Stacks> Stack { get; set; }
        public DbSet<Match> match { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Developer>().Property(p => p.FirstName).IsRequired();
            builder.Entity<Developer>().Property(p => p.LastName).IsRequired();
            builder.Entity<Developer>().Property(p => p.Email).IsRequired();
            builder.Entity<Developer>().Property(p => p.password).IsRequired();
            builder.Entity<Developer>().Property(p => p.BirthDate).IsRequired();

            builder.Entity<Recruiter>().Property(p => p.FirstName).IsRequired();
            builder.Entity<Recruiter>().Property(p => p.LastName).IsRequired();
            builder.Entity<Recruiter>().Property(p => p.Email).IsRequired();
            builder.Entity<Recruiter>().Property(p => p.password).IsRequired();
            builder.Entity<Recruiter>().Property(p => p.BirthDate).IsRequired();

        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
        {
            configuration.Properties<string>().HaveMaxLength(100);
        }
    }
}
