﻿using System;
using System.Collections.Generic;

namespace DBFirst.Models
{
    public partial class UserBook
    {
        public int UserBookId { get; set; }
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }
        public int ReadingStatus { get; set; }

        public virtual Book Book { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
