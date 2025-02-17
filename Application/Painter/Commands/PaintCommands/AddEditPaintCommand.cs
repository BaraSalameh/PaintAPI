using Application.Common.Entities;
using MediatR;

namespace Application.Painter.Commands.PaintCommands
{
    public class AddEditPaintCommand : IRequest<AbstractViewModel>
    {
        public int? ID { get; set; }
        public AEPC_SystemLanguage Name { get; set; }
        public string? ImagePath { get; set; }
        public int? UserID { get; set; }
        //public AEPC_PaintDetails? PaintDetails { get; set; }
    }

    public class AEPC_SystemLanguage
    {
        public int? ID { get; set; }
        public string? Key { get; set; }
        public string? English { get; set; }
        public string? Arabic { get; set; }
        public string? Turkish { get; set; }
    }

    public class AEPC_PaintDetails
    {
        public int? ID { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public AEPC_Dimensions Dimension { get; set; }
        public AEPC_SystemLookup Category { get; set; }
        public AEPC_SystemLookup Status { get; set; }
        public AEPC_SystemLookup Glass { get; set; }
        public AEPC_SystemLookup Frame { get; set; }
    }

    public class AEPC_Dimensions
    {
        public int? ID { get; set; }
        public decimal? Length { get; set; }
        public decimal? Width { get; set; }
        public decimal? Depth { get; set; }
    }

    public class AEPC_SystemLookup
    {
        public int? ID { get; set; }
        public AEPC_LookupCategory LookupCategory { get; set; }
    }

    public class AEPC_LookupCategory
    {
        public int? ID { get; set; }
        public string? Name { get; set; }
    }
}
