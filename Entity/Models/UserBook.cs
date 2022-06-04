using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Models
{
    [Table("user_book")]
    public partial class UserBook
    {
        public int UserBookId { get; set; }
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }
        public ReadingStatusEnum ReadingStatus { get; set; }

        public virtual Book Book { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
