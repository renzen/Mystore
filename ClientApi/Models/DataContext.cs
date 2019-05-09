using Microsoft.EntityFrameworkCore;

namespace clientapi.models{
public class DataContext : DbContext {
  public DataContext(DbContextOptions<DataContext> opts)
  : base(opts) {}
  public DbSet<Item> Items { get; set;}
  public DbSet<Studio> Studios { get; set;}
  public DbSet<Rating> Ratings {get; set;}

}

}