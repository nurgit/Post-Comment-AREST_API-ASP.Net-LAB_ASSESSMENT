using REST_API_ASP.Net.Models;
using REST_API_ASP.Net.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REST_API_ASP.Net.Reposisitores
{
    public class CommentRepository: Repository<Comment>
    {

        public List<Comment> GetCommentsByPost(int id)
        {
            return this.GetAll().Where(X => X.PostId == id).ToList();
        }

    }
}