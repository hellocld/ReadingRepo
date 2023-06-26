using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingRepo.DAL.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string? Isbn { get; set; }
        public string? OpenLibraryId{ get; set; }
        public string? Title { get; set; }
        public Guid AuthorGroupId { get; set; }
        public Uri? CoverImageUri { get; set; }
        public int Pages { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
