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
    public class CommentController : ApiController
    {
        private Service.CommentService CreateCommentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var commentService = new CommentService(userId);
            return commentService;
        }

         public IHttpActionResult Get() 
        {
            CommentService CommentService = CreateCommentService();
            var comments = CommentService.GetComments();
            return Ok(comments);
        }

        //create comment 
        public IHttpActionResult Post(CommentCreate comment) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCommentService();

            if (!service.CreateComment(comment))
                return InternalServerError();

            return Ok();

            
        }

        public IHttpActionResult Get(int id) 
        {
            CommentService CommentService = CreateCommentService();
            var comment = CommentService.GetCommentByPostId(id);
            return Ok(comment);
        }

        public IHttpActionResult Put(CommentEdit comment) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCommentService();

            if (!service.UpdateComment(comment))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id) 
        {
            var service =CreateCommentService();
            if (!service.DeleteComment(id))
                return InternalServerError();

            return Ok();
        }
    }
    
}
