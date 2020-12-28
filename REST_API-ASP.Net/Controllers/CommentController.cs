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
    //[RoutePrefix("api/coments")]
    [RoutePrefix("api/posts/{id}/comments")]
    public class CommentController : ApiController
    {
         CommentRepository commentRepository = new CommentRepository();
        PostRepository postRepository = new PostRepository();
        //[Route("")]
        //public IHttpActionResult Get()
        //{
        //    return Ok(commentRepository.GetAll());
        //}

        //[Route("{id}")]//nothing...just giving a name to this route for next time use
        //public IHttpActionResult Get(int id)
        //{
        //    var post = commentRepository.Get(id);
        //    if (post == null)
        //    {
        //        return StatusCode(HttpStatusCode.NoContent);
        //    }
        //    return Ok(commentRepository.Get(id));
        //}


        //[Route("")]
        //public IHttpActionResult Post(Comment comment)
        //{
        //    commentRepository.Insert(comment);
        //    return Created("api/comments/" + comment.CommentId, comment);


        //}


        //[Route("{id}")]
        //public IHttpActionResult Put([FromUri] int id, [FromBody] Comment comment)
        //{
        //    comment.CommentId = id;
        //    commentRepository.Update(comment);
        //    return Ok(comment);
        //}

        //[Route("{id}")]
        //public IHttpActionResult Delete(int id)
        //{

        //    commentRepository.Delete(id);
        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //----------------------------
        //Get All Comment
        [Route("")]
        public IHttpActionResult Get(int id)
        {

            return Ok(postRepository.GetCommentsByPost(id));
        }

        //Get a Specific Comment
        [Route("{id2}", Name = "GetCommentById")]
        public IHttpActionResult Get(int id, int id2)
        {
            List<Comment> cmt = postRepository.GetCommentsByPost(id);
            Comment comment = commentRepository.GetById(id2);

            bool check = false;
            foreach (var item in cmt)
            {
                if (item.CommentId == comment.CommentId)
                    check = true;
            }

            if (comment == null || check == false)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            return Ok(comment);
        }

        //Create a Comment for a Post
        [Route("")]
        public IHttpActionResult Post([FromBody] Comment com, int id)
        {
            com.PostId = id; //changed here
            commentRepository.Insert(com);
            string url = Url.Link("GetCommentById", new { id = com.CommentId, id2 = com.PostId });
            return Created(url, com);
        }

        //Edit a Comment
        [Route("{id2}")]
        public IHttpActionResult Put([FromBody] Comment com, int id, int id2)
        {

            com.CommentId = id2;
            com.PostId = id;
            commentRepository.Update(com);
            return Ok(com);
        }

        //Delete a Comment
        [Route("{id2}")]
        public IHttpActionResult Delete(int id, int id2)
        {
            List<Comment> cmt = postRepository.GetCommentsByPost(id);
            Comment comment = commentRepository.GetById(id2);
            bool check = false;
            foreach (var item in cmt)
            {
                if (item.CommentId == comment.CommentId)
                    check = true;
            }

            if (check == false)
            {
                return StatusCode(HttpStatusCode.Unauthorized);
            }

            commentRepository.Delete(id2);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
