using Microsoft.EntityFrameworkCore;


namespace ReadingRepo.DAL.Entities
{
    public class ReadingRepoContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<ReadingLog> ReadingLogs { get; set; }

        public string DbPath { get; }
        public ReadingRepoContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "readingrepo.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options
                .UseSqlite($"Data Source={DbPath}")
                .EnableSensitiveDataLogging();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var seedAuthors = new Author[]
            {
                new Author
                {
                    AuthorId = Guid.NewGuid(),
                    FirstName = "Groucho",
                    LastName = "Marx",
                },
                new Author
                {
                    AuthorId = Guid.NewGuid(),
                    FirstName = "Harpo",
                    LastName = "Marx",
                },
            };

            var seedBook = new Book
            {
                BookId = Guid.NewGuid(),
                Title = "Hail Freedonia",
                PublishDate = new DateTime(1933, 11, 17),
                Pages = 68,
            };

            Dictionary<string, object>[] seedAuthorBook = new Dictionary<string, object>[]
            {
                new Dictionary<string, object>{
                    { "AuthorsAuthorId", seedAuthors[0].AuthorId },
                    { "BooksBookId", seedBook.BookId }
                },
                new Dictionary<string, object>
                {
                    { "AuthorsAuthorId", seedAuthors[1].AuthorId },
                    { "BooksBookId", seedBook.BookId }
                }
            };

            modelBuilder.Entity<Book>()
                .HasData(seedBook);

            modelBuilder.Entity<Author>()
                .HasData(seedAuthors);

            modelBuilder.SharedTypeEntity<Dictionary<string, object>>("AuthorBook", builder =>
            {
                builder.HasData(seedAuthorBook);
            });
        }
    }
}
