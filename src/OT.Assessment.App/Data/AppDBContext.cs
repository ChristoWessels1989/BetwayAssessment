using Microsoft.EntityFrameworkCore;
using OT.Assessment.App.Models;

namespace OT.Assessment.App.Data
{
  public class AppDBContext : DbContext
  {
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
    {

    }
    public DbSet<Player> Players { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<Provider> Providers { get; set; }
    public DbSet<CasinoWager> CasinoWagers { get; set; }
  }
}