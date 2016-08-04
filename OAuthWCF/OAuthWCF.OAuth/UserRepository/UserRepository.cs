using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace OAuthWCF.OAuth.UserRepository
{
    public class UserRepository:IRepository<UserEntity>
    {
        string _connectionString;
        public UserRepository( string connectionString)
        {
            _connectionString = connectionString;
        }

        public UserEntity Get(object id)
        {
            throw new System.NotImplementedException();
        }

        public void Attach(UserEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<UserEntity> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Insert(UserEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(UserEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public void SubmitChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}