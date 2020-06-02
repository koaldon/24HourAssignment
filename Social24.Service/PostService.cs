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

        private readonly Guid _userID;

        public PostService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreatePost(PostCreate model)
        {
            var entity =
            new Post()
            {
                OwnerId = _userID,
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
                    .Where(e => e.OwnerId == _userID)
                    .Select(
                       e =>
                       new PostListItem
                       {
                           PostID = e.PostID,
                           Title = e.Title,
                           CreatedUtc = e.CreatedUtc
                       }
                    );
                    
                return query.ToArray();
            }

        }

        public PostDetails GetPostByPostId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Posts
                    .Single(e => e.PostID == id && e.OwnerId == _userID);
                return new PostDetails
                {
                    PostId = entity.PostID,
                    Title = entity.Title,
                    Text = entity.Text,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc
                };
            }
        }

        public bool UpdatePost(PostEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Posts
                    .Single(e => e.PostID == model.PostId);

                entity.Title = model.Title;
                entity.Text = model.Text;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePost(int postId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Posts
                    .Single(e => e.PostID == postId);
                ctx.Posts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }


    }

}

