using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingRepo.DAL.Entities
{
    public class ReadingLog
    {
        public enum States
        {
            NONE,
            TO_ACQUIRE,
            TO_READ,
            READING,
            READ
        }

        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public States State { get; set; }
    }
}
