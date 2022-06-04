using Entities.ExtendedModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    
    [Table("user")]
    public class User
    {
        [Column("UserId")]
        public Guid Id { get; set; }

        [Column("FullName")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Date created is required")]
        public DateTime DateCreated { get; set; }
        public List<UserBook> UserBooks { get; set; }
    }
}
