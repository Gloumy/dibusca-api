using Microsoft.EntityFrameworkCore;

namespace dibusca_api.Models
{
  public class AppDbContext : DbContext
  {
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer("Server=localhost;Database=dibusca;user id=SA;password=pwdM$SQLS3rver;persist security info=True;MultipleActiveResultSets=true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<User>().ToTable("Users");
    }
  }
}