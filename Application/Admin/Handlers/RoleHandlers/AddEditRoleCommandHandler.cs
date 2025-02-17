using Application.Admin.Commands.RoleCommands;
using Application.Admin.MappingProfiles;
using Application.Common.Entities;
using AutoMapper;
using DataAccess.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Admin.Handlers.RoleHandlers
{
    public class AddEditRoleCommandHandler : IRequestHandler<AddEditRoleCommand, AbstractViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public AddEditRoleCommandHandler(IAppDbContext context)
        {
            _context = context;
            _mapper = new RoleMappingProfiles().AddEditRoleCommandHandler();
        }

        public async Task<AbstractViewModel> Handle(AddEditRoleCommand request, CancellationToken cancellationToken)
        {
            var Output = new AbstractViewModel();
            var ResultToDB = _mapper.Map<Role>(request);

            if (request.ID == null)
            {
                _context.Role.Add(ResultToDB);
            }
            else
            {
                var oldRole =
                    await _context.Role
                        .FindAsync(request.ID);

                if (oldRole == null)
                {
                    Output.lstError.Add("Role not found");
                    return Output;
                }

                _mapper.Map(request, oldRole);
            }

            try
            {
                await _context.SaveChangesAsync();
                Output.status = true;
            }
            catch
            {
                Output.lstError.Add("Error while adding/updating the Role");
            }

            return Output;
        }
    }
}
