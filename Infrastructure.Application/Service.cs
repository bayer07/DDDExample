using AutoMapper;
using Contracts;
using Domain;

namespace Infrastructure.Application
{
    public class Service : IService
    {
        public Service(IUserDao userDao, IMapper mapper)
        {
            this.userDao = userDao;
            this.mapper = mapper;
        }

        private readonly IUserDao userDao;
        private readonly IMapper mapper;

        public ApplicationFuu GetFuu(int id)
        {
            var fuu = userDao.GetFuu(id);
            var applicationFuu = mapper.Map<DomainFuu, ApplicationFuu>(fuu);
            return applicationFuu;
        }
    }
}
