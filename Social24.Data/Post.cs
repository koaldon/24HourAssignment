using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social24.Data
{
    public class Post
    {
        [Key]
        public int PostID { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset ModifiedUtc { get; set; }

        public bool isLiked { get; set; } = false;
        public virtual int User {get;set;}
    }
}
