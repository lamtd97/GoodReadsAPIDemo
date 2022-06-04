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
    [Table("book")]
    public class Book
    {
        [Column("BookId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(255, ErrorMessage = "Name can't be longer than 255 characters")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime? DatePublication { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(1024, ErrorMessage = "Address cannot be loner then 1024 characters")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Cover is required")]
        [StringLength(65000, ErrorMessage = "Cover cannot be loner then 65000 characters")]
        public string? Cover { get; set; }

        public List<UserBook> UserBooks { get; set; }
    }
}
