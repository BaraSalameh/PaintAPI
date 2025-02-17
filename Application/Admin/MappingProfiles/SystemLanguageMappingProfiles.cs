using Application.Admin.Commands.SystemLanguageCommands;
using Application.Admin.Queries.SystemLanguageQueries;
using AutoMapper;
using Domain.Entities;

namespace Application.Admin.MappingProfiles
{
    public class SystemLanguageMappingProfiles
    {
        public IMapper AddEditSystemLanguageCommandHandler()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AddEditSystemLanguageCommand, System_Language>();
            });
            return config.CreateMapper();
        }

        public IMapper SystemLanguageListQueryHandler()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<System_Language, SLLQ_SystemLanguageListQuery>();
            });
            return config.CreateMapper();
        }
    }
}
