using REST_API_ASP.Net.Models;
using REST_API_ASP.Net.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REST_API_ASP.Net.Repository
{
    public class PostRepository:Repository<Post>
    {
        public List<Comment> GetCommentsByPost(int id)
        {
            return this.context.Comments.Where(x => x.PostId == id).ToList();
        }

    }
}