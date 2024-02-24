using ApplicationNews;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace ApplicationNews
{
    public class NewsDbContext : DbContext
    {

        public NewsDbContext():base()
        {
        }

        public NewsDbContext(DbContextOptions options) : base(options)
        {
          
           
        }
        public DbSet<NewsItem> NewsItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (Debugger.IsAttached)
            {
                optionsBuilder.UseInMemoryDatabase("blazamNews");
            }
            else
            {
                optionsBuilder.UseMySql("Database=localdb;Data Source=127.0.0.1;User Id=azure;Password=6#vWHD_$", serverVersion: new MySqlServerVersion(new Version(8, 0, 32)),
                                  mySqlOptionsAction: options =>
                                  {
                                      options.EnableRetryOnFailure();
                                      //options.SetSqlModeOnOpen();

                                  }).EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
