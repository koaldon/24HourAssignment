using Microsoft.AspNet.Identity;
using Social24.Models;
using Social24.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Social24.Controllers
{
    public class PostController : ApiController
    {
        private Service.PostService CreatePostService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var postService = new PostService(userId);
            return postService;
        }


        public IHttpActionResult Get()
        {
            PostService PostService = CreatePostService();
            var Posts = PostService.GetPosts();
            return Ok(Posts);
        }

        //create Post 
        public IHttpActionResult Post(PostCreate Post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePostService();

            if (!service.CreatePost(Post))
                return InternalServerError();

            return Ok();


        }

        public IHttpActionResult Get(int id)
        {
            PostService PostService = CreatePostService();
            var Post = PostService.GetPostByPostId(id);
            return Ok(Post);
        }

        public IHttpActionResult Put(PostEdit Post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePostService();

            if (!service.UpdatePost(Post))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreatePostService();
            if (!service.DeletePost(id))
                return InternalServerError();

            return Ok();
        }
    }
}

