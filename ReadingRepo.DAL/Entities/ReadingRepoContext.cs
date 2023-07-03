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
                    AuthorId = Guid.Parse("84F3F98B-82E5-445F-8E8C-DF30AFCD7CBF"),
                    FirstName = "Groucho",
                    LastName = "Marx",
                },
                new Author
                {
                    AuthorId = Guid.Parse("F135FEC5-71B8-4BE7-8D55-7301D6F1ECAB"),
                    FirstName = "Harpo",
                    LastName = "Marx",
                },
            };

            var seedBook = new Book
            {
                BookId = Guid.Parse("C7882C3F-98DC-4553-9835-65872CF9D3A4"),
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

            var seedReadingLog = new ReadingLog
            {
                BookId = seedBook.BookId,
                StartDate = new DateTime(2001, 10, 01),
                State = ReadingLog.States.READING,
                Id = Guid.Parse("3b253915-1e10-477c-92ab-effb0cb896b4")
            };

            modelBuilder.Entity<Book>()
                .HasData(seedBook);

            modelBuilder.Entity<Author>()
                .HasData(seedAuthors);

            modelBuilder.SharedTypeEntity<Dictionary<string, object>>("AuthorBook", builder =>
            {
                builder.HasData(seedAuthorBook);
            });

            modelBuilder.Entity<ReadingLog>()
                .HasData(seedReadingLog);
        }
    }
}
