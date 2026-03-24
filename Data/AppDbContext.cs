using Microsoft.EntityFrameworkCore;
using netcsharp_api.Models;

namespace netcsharp_api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Person> People { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().ToTable("person");
        modelBuilder.Entity<Person>().Property(p => p.Id).HasColumnName("id");
        modelBuilder.Entity<Person>().Property(p => p.FirstName).HasColumnName("first_name");
        modelBuilder.Entity<Person>().Property(p => p.LastName).HasColumnName("last_name");
        modelBuilder.Entity<Person>().Property(p => p.Email).HasColumnName("email");
        modelBuilder.Entity<Person>().Property(p => p.Phone).HasColumnName("phone");
    }
}