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
    [RoutePrefix("api/posts")]
    public class PostController : ApiController
    {
        ComentRepository postRepository = new ComentRepository();
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(postRepository.GetAll());
        }

        [Route("{id}", Name ="GetPostById")]//nothing...just giving a name to this route for next time use
        public IHttpActionResult Get(int id)
        {
            var post = postRepository.Get(id);
            if (post == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(postRepository.Get(id));
        }

        [Route("")]
        public IHttpActionResult Post(Post post)
        {
            string uri = Url.Link("GetPostById", new { id=post.PostId});
            postRepository.Insert(post);
            return Created(uri, post);
        }

        [Route("")]
        public IHttpActionResult Put([FromUri] int id,[FromBody]Post post)
        {
            post.PostId = id;
            postRepository.Update(post);
            return Ok(post);
        }

        [Route("{id}")]
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
