using Application.Admin.Commands.UserCommands;
using Application.Admin.MappingProfiles;
using Application.Admin.Validations;
using Application.Common.Entities;
using Application.Common.Functions;
using AutoMapper;
using DataAccess.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Admin.Handlers.UserHandlers
{
    public class AddEditUserCommandHandler : IRequestHandler<AddEditUserCommand, AbstractViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public AddEditUserCommandHandler(IAppDbContext context)
        {
            _context = context;
            _mapper = new UserMappingProfiles().AddEditUserCommandHandler();
        }

        public async Task<AbstractViewModel> Handle(AddEditUserCommand request, CancellationToken cancellationToken)
        {
            var Output = new AbstractViewModel();
            var ResultToDB = _mapper.Map<User>(request);

            Output.lstError = ResultToDB.ValidateUser(Output.lstError);
            if (Output.lstError.Count > 0)
            {
                return Output;
            }

            if (request.ID == null)
            {
                ResultToDB.Password = request.Password!.Encrypt(true);
                _context.User.Add(ResultToDB);
            }
            else
            {
                var oldUser = 
                    await _context.User
                        .Where(u => u.ID == request.ID && u.IsActive == true)
                        .FirstOrDefaultAsync();

                if (oldUser == null)
                {
                    Output.lstError.Add("User not found");
                    return Output;
                }

                _mapper.Map(request, oldUser);
                oldUser.Password = request.Password!.Encrypt(true);
            }

            try
            {
                await _context.SaveChangesAsync();
                Output.status = true;
            }
            catch
            {
                Output.lstError.Add("Error while adding/updating the user");
            }
            
            return Output;
        }
    }
}
