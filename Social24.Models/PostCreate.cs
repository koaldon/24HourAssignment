using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social24.Models
{
   public class PostCreate
    {
        [Required]
        [MinLength(5, ErrorMessage = "Please enter at least 5 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Title { get; set; }
        public string Text { get; set; }

    }
}
