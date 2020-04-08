using Domain;

namespace Infrastructure.Application
{
    public class Service : IService
    {
        public Service(IUserDao userDao)
        {
            this.userDao = userDao;
        }

        private readonly IUserDao userDao;

        public Fuu GetUser(int id)
        {
            return userDao.GetUser(id);
        }
    }
}
