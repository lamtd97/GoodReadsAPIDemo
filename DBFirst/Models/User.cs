using System;
using System.Collections.Generic;

namespace DBFirst.Models
{
    public partial class User
    {
        public User()
        {
            UserBooks = new HashSet<UserBook>();
        }

        public Guid UserId { get; set; }
        public string FullName { get; set; } = null!;
        public DateTime DateCreated { get; set; }

        public virtual ICollection<UserBook> UserBooks { get; set; }
    }
}
