using Microsoft.EntityFrameworkCore;

namespace AspMvcQuestRoom.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Models.QuestRoom> QuestRooms { get; set; }

        private string sqlConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=QuestRoom;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(sqlConnectionString);
        }
    }
}
