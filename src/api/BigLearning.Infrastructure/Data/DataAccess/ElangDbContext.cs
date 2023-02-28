using System.Reflection;
using Elang.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Elang.Infrastructure.Data.DataAccess;

internal class ElangDbContext : DbContext
{
    public ElangDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Card> Cards { get; set; } = null!;

    public DbSet<Topic> Topics { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("public");
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
