using PersonalAccounting.Model.Model;
using PersonalAccounting.Model.Repositories;
using System.Linq;
using System.Data.Entity;

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
            try
            {
                _db.Entry(user).State = EntityState.Deleted;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string GetPassword()
        {
            return _db.User.Select(u => u.Password).FirstOrDefault();
        }

        public bool InsertUser(User user)
        {
            try
            {
                _db.User.Add(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateUser(User user)
        {
            try
            {
                _db.Entry(user).State = EntityState.Modified;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UserExist()
        {
            return _db.User.Any();
        }
    }
}
