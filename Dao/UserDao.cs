using Domain;

namespace Dao
{
    public class UserDao : IUserDao
    {
        public Fuu GetUser(int id)
        {
            return new Fuu { Name = "User" + id };
        }
    }
}
