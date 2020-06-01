using Social24.Data;
using Social24.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Social24.Service
{
    public class PostService
    {
        public bool CreatePost(PostCreate model)
        {
            var entity =
            new Post()
            {
                OwnerID = _userID,
                Title = model.Title,
                Text = model.Text,
                CreatedUtc = DateTimeOffset.Now

            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PostListItem> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Posts
                    .Where(e => e.OwnerID == _userID)
                    .Select(
                       else =>
                       new PostListItem
                       {
                           PostID = e.PostID,
                           Title = e.Title,
                           CreatedUtc = e.CreatedUtc
                       }
                    );
            }

            return query.ToArray();
        
        }
    }

}

