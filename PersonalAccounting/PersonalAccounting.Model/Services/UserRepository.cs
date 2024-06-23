using PersonalAccounting.Model.Model;
using PersonalAccounting.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.Model.Services
{
    public class UserRepository : IUserRepository
    {
        private Accounting_DBEntities _db;

        public UserRepository(Accounting_DBEntities db)
        {
            _db = db;
        }

        public bool DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public string GetPassword()
        {
            throw new NotImplementedException();
        }

        public bool InsertUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool UserExist()
        {
            throw new NotImplementedException();
        }
    }
}
