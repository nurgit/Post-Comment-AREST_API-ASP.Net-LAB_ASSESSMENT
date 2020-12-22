using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST_API_ASP.Net.Repositories
{
    interface IRepository<T> where T:class
    {
        List<T> GetAll();
        T Get(int id);
        T GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
