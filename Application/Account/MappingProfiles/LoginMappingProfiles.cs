using Application.Account.Queries.LoginQueries;
using AutoMapper;
using Domain.Entities;

namespace Application.Account.MappingProfiles
{
    public class LoginMappingProfiles
    {
        public IMapper LoginQueryHandler()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, LQ_Response>();
            });
            return config.CreateMapper();
        }
    }
}
