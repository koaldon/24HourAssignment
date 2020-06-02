//using Social24.Data;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Social24.Models
//{
//    public class LikeItemList
//    {
//        public int LikeId { get; set; }
//        public User Liker { get; set; }   //Thisobject would be better if it were a UserDetail or UserListItem, because User is in the Data Layer
//        public Post LikedPost { get; set; }

//        [Display(Name = "Created")]
//        public DateTimeOffset CreatedUtc { get; set; }
//    }
//}
