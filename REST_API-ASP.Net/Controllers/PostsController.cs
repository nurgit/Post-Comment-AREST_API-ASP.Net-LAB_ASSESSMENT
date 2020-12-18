using REST_API_ASP.Net.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace REST_API_ASP.Net.Controllers
{
    public class PostsController : ApiController
    {
        PostRepository postRepository = new PostRepository();
        public IHttpActionResult Get()
        {
            return Ok(postRepository.GetAll());
        }
        public IHttpActionResult Get(int id)
        {
            var post = postRepository.Get(id);
            if (post==null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(postRepository.Get(id));
        }
    }
}
