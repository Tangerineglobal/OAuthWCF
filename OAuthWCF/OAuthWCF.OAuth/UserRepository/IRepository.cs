using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAuthWCF.OAuth
{
    public interface IRepository<T> where T : class
    {
        T Get(object id);
        void Attach(T entity);
        IQueryable<T> GetAll();
        void Insert(T entity);
        void Delete(T entity);
        void SubmitChanges();
    }
}