using Microsoft.AspNet.Identity;
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
            var noteService = new CommentService(userId);
            return noteService;
        }

    }
}
