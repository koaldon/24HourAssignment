using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social24.Data
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [MaxLength(200, ErrorMessage ="There Are too many characters in this field.")]
        public string Text { get; set; }
        //public User Author { get; set; }
        //public Post CommentPost {get; set;}
    }
}
