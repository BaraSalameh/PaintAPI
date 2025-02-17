using Application.Admin.Commands.UserCommands;
using Application.Admin.Queries.UserQueries;
using AutoMapper;
using Domain.Entities;

namespace Application.Admin.MappingProfiles
{
    public class UserMappingProfiles
    {
        public IMapper UsersListQueryHandler()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, ULQ_UsersListQuery>();
                cfg.CreateMap<Role, ULQ_Role>();
            });
            return config.CreateMapper();
        }

        public IMapper AddEditUserCommandHandler()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AddEditUserCommand, User>();
            });
            return config.CreateMapper();
        }
    }
}
