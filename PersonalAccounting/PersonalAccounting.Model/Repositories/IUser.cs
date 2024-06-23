using PersonalAccounting.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.Model.Repositories
{
    internal interface IUser
    {
        bool InsertUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(User user);
        string GetPassword();
        bool UserExist();
    }
}
