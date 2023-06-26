using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingRepo.DAL.Entities
{
    public class AuthorGroup
    {
        public Guid GroupId { get; set; }
        public Guid AuthorId { get; set; }
    }
}
