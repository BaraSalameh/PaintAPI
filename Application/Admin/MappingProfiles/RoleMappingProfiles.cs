using Application.Admin.Commands.RoleCommands;
using Application.Admin.Queries.RoleQueries;
using AutoMapper;
using Domain.Entities;

namespace Application.Admin.MappingProfiles
{
    public class RoleMappingProfiles
    {
        public IMapper AddEditRoleCommandHandler()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AddEditRoleCommand, Role>();
            });
            return config.CreateMapper();
        }

        public IMapper RolesListQueryHandler()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Role, RLQ_RolesListQuery>();
            });
            return config.CreateMapper();
        }
    }
}
