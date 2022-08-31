using Microsoft.EntityFrameworkCore;
using TodoAPI.Datas;

namespace TodoAPI
{
    public class MyDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public MyDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

       

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("MyDB"));
        }

        public DbSet<User> UserDB { get; set; }
        public DbSet<Datas.Task> TaskDB { get; set; }

    }
}
