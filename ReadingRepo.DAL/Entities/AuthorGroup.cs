using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingRepo.DAL.Entities
{
    [PrimaryKey(nameof(GroupId), nameof(AuthorId))]
    public class AuthorGroup
    {

        public Guid GroupId { get; set; }
        public Guid AuthorId { get; set; }
    }
}
