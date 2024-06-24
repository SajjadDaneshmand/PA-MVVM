using PersonalAccounting.Model.Model;


namespace PersonalAccounting.Model.Repositories
{
    public interface IUserRepository
    {
        bool InsertUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(User user);
        string GetPassword();
        bool UserExist();
    }
}
