using Entities.Enums;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ExtendedModels
{
    
    public class UserBookMinium
    {
        [Key]
        public int UserBookId { get; set; }
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }

        public BookReadStatus ReadingStatus { get; set; }

    }
    [Table("user_book")]
    public class UserBook : UserBookMinium
    {
        //public int UserBookId { get; set; }
        //public Guid BookId { get; set; }
        //public Guid UserId { get; set; }

        //public BookReadStatus ReadingStatus { get; set; }
        public Book Book { get; set; }


        public User User { get; set; }


    }
}
