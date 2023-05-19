using DataLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace DataLayer;

public class DataContext: DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "Newham");
    }

    public DbSet<FAQ> FAQs { get; set; }
}

