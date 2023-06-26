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
            DbPath = Path.Join(path, "readingrepo.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var dummyAuthorGroupId = Guid.NewGuid();
            var dummyAuthor1Id = Guid.NewGuid();
            var dummyAuthor2Id = Guid.NewGuid();

            modelBuilder.Entity<Book>()
                .HasData(new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "Hail Freedonia",
                    AuthorGroupId = dummyAuthorGroupId,
                });

            modelBuilder.Entity<Author>()
                .HasData(new List<Author>
                {
                    new Author
                    {
                        Id = dummyAuthor1Id,
                        FirstName = "Groucho",
                        LastName = "Marx"
                    },
                    new Author
                    {
                        Id = dummyAuthor2Id,
                        FirstName = "Harpo",
                        LastName = "Marx"
                    },
                });

            modelBuilder.Entity<AuthorGroup>()
                .HasData(new List<AuthorGroup>
                {
                    new AuthorGroup
                    {
                        GroupId = dummyAuthorGroupId,
                        AuthorId = dummyAuthor1Id,
                    },
                    new AuthorGroup
                    {
                        GroupId = dummyAuthorGroupId,
                        AuthorId = dummyAuthor2Id,
                    },
                });
        }
    }
}
