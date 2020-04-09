using Domain;

namespace Dao
{
    public class UserDao : IUserDao
    {
        public DomainFuu GetFuu(int id)
        {
            return new DomainFuu { Name = "User" + id };
        }
    }
}
