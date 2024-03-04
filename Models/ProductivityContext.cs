using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using SQLitePCL;

namespace WebDevCWK.Models;

public class ProductivityContext:IdentityDbContext<IdentityUser>
{
    public ProductivityContext(DbContextOptions<ProductivityContext> options):base(options)
    {}

    public DbSet<Users> Users {get;set;}
    public DbSet<UserRoles> UserRoles {get;set;}
    public DbSet<Teams> Teams {get;set;}
    public DbSet<Projects> Projects {get;set;}
    public DbSet<Tasks> Tasks {get;set;}
    public DbSet<Milestones> Milestones {get;set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Fix for IdentityLogin primary key issue:
        //Note to self: This needs to use the base of OnModelCreating to access IdentityDbContext method
        //Special thanks: https://stackoverflow.com/questions/40703615/the-entity-type-identityuserloginstring-requires-a-primary-key-to-be-defined 
        base.OnModelCreating(modelBuilder);

        // One2Many

        modelBuilder.Entity<Users>()
            .HasMany(u => u.Tasks)
            .WithOne(t => t.Users)
            .HasForeignKey(t => t.UserID);

        modelBuilder.Entity<Projects>()
            .HasMany(p => p.Milestones)
            .WithOne(m => m.Project)
            .HasForeignKey(m => m.ProjectID);

        modelBuilder.Entity<Users>()
            .HasMany(u => u.UserRoles)
            .WithOne(ur => ur.Users)
            .HasForeignKey(ur => ur.UserID);

        // Many2Many

        modelBuilder.Entity<Users>(entity =>
        {
            entity.HasMany(u => u.Teams)
                .WithMany(t => t.Users)
                .UsingEntity<UserTeam>(
                    j =>
                    {
                        j.HasKey(ut => new { ut.UserID, ut.TeamID }); 
                        j.ToTable("UserTeams"); 
                    });
        });

    }
}