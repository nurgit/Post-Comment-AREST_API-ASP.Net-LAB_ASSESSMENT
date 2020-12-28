using REST_API_ASP.Net.Reposisitores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace REST_API_ASP.Net.Controllers
{
    [RoutePrefix("api/allComments")]
    public class AllCommetController : ApiController
    {

        CommentRepository commentRepository = new CommentRepository();
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(commentRepository.GetAll());
        }
    }
}
