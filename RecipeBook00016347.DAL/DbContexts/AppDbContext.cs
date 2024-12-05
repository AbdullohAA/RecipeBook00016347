using Microsoft.EntityFrameworkCore;
using RecipeBook00016347.Domain.Entities;

namespace RecipeBook00016347.DAL.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<RecipeBook> RecipeBooks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Recipe>()
            .HasOne(r => r.RecipeBook)
            .WithMany(rb => rb.Recipes)
            .HasForeignKey(r => r.RecipeBookId)
            .OnDelete(DeleteBehavior.Cascade);

    }


}
