using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Collections.Generic;

namespace Enigmyster.Models
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DatabaseContext>();
            builder.UseSqlServer(

                //TODO, better than this..

                //"Data Source=SQL6001.site4now.net;Initial Catalog=DB_A4355F_enigmyster;User Id=DB_A4355F_enigmyster_admin;Password=XXX;"



               "Server=.\\SQLEXPRESS;Database=Enigmyster;Trusted_Connection=True;MultipleActiveResultSets=true"
);
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
