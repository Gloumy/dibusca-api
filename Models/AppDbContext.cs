using Microsoft.EntityFrameworkCore;

namespace dibusca_api.Models
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer("Server=localServer;Database=base_test;user id=root;password=root;persist security info=True;MultipleActiveResultSets=true");
    }
  }
}