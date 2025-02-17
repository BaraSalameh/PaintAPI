using Application.Common.Entities;
using Application.Painter.Commands.PaintCommands;
using Application.Painter.MappingProfiles;
using Application.Painter.Validations;
using AutoMapper;
using DataAccess.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Painter.Handlers.PaintHandlers
{
    public class AddEditPaintCommandHandler : IRequestHandler<AddEditPaintCommand, AbstractViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public AddEditPaintCommandHandler(IAppDbContext context)
        {
            _context = context;
            _mapper = new PaintMappingProfiles().AddEditPaintCommandHandler();
        }

        public async Task<AbstractViewModel> Handle(AddEditPaintCommand request, CancellationToken cancellationToken)
        {
            var Output = new AbstractViewModel();
            var ResultToDB = _mapper.Map<Paint>(request);

            Output.lstError = ResultToDB.ValidatePaint(Output.lstError);
            if(Output.lstError.Count > 0)
            {
                Output.status = false;
                return Output;
            }

            if (request.ID == null)
            {
                _context.Paint.Add(ResultToDB);
            }
            else
            {
                var oldPaint =
                    await _context.Paint
                        .FindAsync(request.ID);

                if (oldPaint == null)
                {
                    Output.lstError.Add("Paint not found");
                    Output.status = false;
                    return Output;
                }

                _mapper.Map(request, oldPaint);
            }

            try
            {
                await _context.SaveChangesAsync();
                Output.status = true;
            }
            catch
            {
                Output.lstError.Add("Error while adding/updating paint");
                Output.status = false;
            }

            return Output;
        }
    }
}
