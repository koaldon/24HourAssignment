//using Social24.Data;
//using Social24.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Social24.Service
//{
//    public class LikeService
//    {
//        public bool CreateLike(LikeCreate model) 
//        {
//            var entity = new Like
//            {
//                LikedPost = model.LikedPost,
//                Liker = model.Liker
//            };

//            using (var ctx = new ApplicationDbContext()) 
//            {
//                ctx.Likes.Add(entity);
//                return ctx.SaveChanges() == 1;
//            }
//        }
//    }
//}
