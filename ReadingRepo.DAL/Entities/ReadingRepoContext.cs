using Microsoft.EntityFrameworkCore;


namespace ReadingRepo.DAL.Entities
{
    public class ReadingRepoContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorGroup> AuthorGroups { get; set; }
        public DbSet<ReadingLog> ReadingLogs { get; set; }

        public string DbPath { get; }

        public ReadingRepoContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "readingrepo.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }
        
        
    }
}
