using REST_API_ASP.Net.Models;
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
    [RoutePrefix("api/comments")]
    public class CommentController : ApiController
    {
         CommentRepository commentRepository = new CommentRepository();
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(commentRepository.GetAll());
        }

        [Route("{id}", Name = "GetCommenttById")]//nothing...just giving a name to this route for next time use
        public IHttpActionResult Get(int id)
        {
            var post = commentRepository.Get(id);
            if (post == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(commentRepository.Get(id));
        }

        [Route("")]
        public IHttpActionResult Post(Comment comment)
        {

            commentRepository.Insert(comment);
            return Created("api/posts/" + comment.CommentId, comment);
        }

        [Route("{id}")]
        public IHttpActionResult Put([FromUri] int id, [FromBody] Comment comment)
        {
            comment.PostId = id;
            commentRepository.Update(comment);
            return Ok(comment);
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {

            commentRepository.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
