using Application.Admin.Commands.UserCommands;
using Application.Common.Entities;
using DataAccess.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Admin.Handlers.UserHandlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, AbstractViewModel>
    {
        private readonly IAppDbContext _context;

        public DeleteUserCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<AbstractViewModel> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var Output = new AbstractViewModel();

            var UserToDelete =
                await _context.User
                    .Where(u => u.ID == request.ID && u.IsActive == true)
                    .FirstOrDefaultAsync();

            if (UserToDelete == null)
            {
                Output.status = false;
                Output.lstError.Add("User not found");
                return Output;
            }
          
            try
            {
                UserToDelete.IsActive = false;
                await _context.SaveChangesAsync();
                Output.status = true;
            }
            catch
            {
                Output.lstError.Add("Error while Inactivating the user");
            }

            return Output;
        }
    }
}
