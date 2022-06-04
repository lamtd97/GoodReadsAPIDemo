using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class UserBookVM
    {
        public int UserBookId { get; set; }
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }
        public ReadingStatusEnum ReadingStatus { get; set; }
    }
}
