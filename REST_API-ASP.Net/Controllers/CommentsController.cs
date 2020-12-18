using REST_API_ASP.Net.Reposisitores;
using REST_API_ASP.Net.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace REST_API_ASP.Net.Controllers
{
    public class CommentsController : ApiController
    {
         CommentRepository commmenttRepository = new CommentRepository();
        public IHttpActionResult Get()
        {
            return Ok(commmenttRepository.GetAll());
        }
    }
}
