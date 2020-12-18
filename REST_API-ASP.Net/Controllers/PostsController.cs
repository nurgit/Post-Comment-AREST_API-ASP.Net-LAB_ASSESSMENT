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
    public class PostsController : ApiController
    {
        ComentRepository postRepository = new ComentRepository();
        public IHttpActionResult Get()
        {
            return Ok(postRepository.GetAll());
        }
        public IHttpActionResult Get(int id)
        {
            var post = postRepository.Get(id);
            if (post == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(postRepository.Get(id));
        }

        public IHttpActionResult Post(Post post)
        {

            postRepository.Insert(post);
            return Created("api/posts/" + post.PostId, post);
        }
        public IHttpActionResult Put([FromUri] int id,[FromBody]Post post)
        {
            post.PostId = id;
            postRepository.Update(post);
            return Ok(post);
        }

        public IHttpActionResult Delete(int id)
        {

            postRepository.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }


        //----GetCommentsByPost
    
        [Route("api/posts/{id}/comments")]

        public IHttpActionResult GetCommentsByPostId(int id)
        {
            CommentRepository commentRepository = new CommentRepository();
            return Ok(commentRepository.GetCommentsByPost(id));
        }
    }
}
