using Application.Painter.Commands.PaintCommands;
using AutoMapper;
using Domain.Entities;

namespace Application.Painter.MappingProfiles
{
    public class PaintMappingProfiles
    {
        public IMapper AddEditPaintCommandHandler()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AddEditPaintCommand, Paint>();
                cfg.CreateMap<AEPC_SystemLanguage, System_Language>();
                cfg.CreateMap<AEPC_Dimensions, Dimension>();
                cfg.CreateMap<AEPC_SystemLookup, System_Lookup>();
                cfg.CreateMap<AEPC_LookupCategory, Lookup_Category>();
            });
            return config.CreateMapper();
        }
    }
}
