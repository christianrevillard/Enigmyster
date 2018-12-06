using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Enigmyster.Models
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("connectionsettings.Development.json")
//                .AddJsonFile("connectionsettings.Production.json")
                .Build();

            var builder = new DbContextOptionsBuilder<DatabaseContext>();
            builder.UseSqlServer(configuration["ConnectionString:EnigmysterDb"]);
            return new DatabaseContext(builder.Options);
        }
    }

    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { }

        public DbSet<Riddle> Riddle { get; set; }
    }

    public class Riddle
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Solution { get; set; }
    }
}
