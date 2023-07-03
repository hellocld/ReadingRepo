using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingRepo.DAL.Entities
{
    public class Author
    {
        public Guid AuthorId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public ICollection<Book>? Books { get; set; }
    }
}
