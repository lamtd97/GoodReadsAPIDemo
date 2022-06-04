using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Models
{
    [Table("book")]
    public partial class Book
    {
        public Book()
        {
            UserBooks = new HashSet<UserBook>();
        }

        public Guid BookId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime DatePublication { get; set; }
        public string Description { get; set; } = null!;
        public string Cover { get; set; } = null!;

        public virtual ICollection<UserBook> UserBooks { get; set; }
    }
}
