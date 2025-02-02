﻿using REST_API_ASP.Net.Models;
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
        PostRepository postRepository = new PostRepository();
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(postRepository.GetAll());
        }
        [Route("{id}")]
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
 
            postRepository.Insert(post);
            return Created("api/posts/"+ post.PostId, post);
        }

        [Route("{id}")]
        public IHttpActionResult Put([FromUri] int id, [FromBody] Post post)
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

        //[Route("{id}/comments")]

        //public IHttpActionResult GetCommentsByPostId(int id)
        //{
        //    CommentRepository commentRepository = new CommentRepository();
        //    return Ok(commentRepository.GetCommentsByPost(id));
        //}
    }
}
