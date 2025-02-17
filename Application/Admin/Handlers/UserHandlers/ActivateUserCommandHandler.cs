using Application.Admin.Commands.UserCommands;
using Application.Common.Entities;
using DataAccess.Interfaces;
using MediatR;

namespace Application.Admin.Handlers.UserHandlers
{
    public class ActivateUserCommandHandler : IRequestHandler<ActivateUserCommand, AbstractViewModel>
    {
        private readonly IAppDbContext _context;

        public ActivateUserCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<AbstractViewModel> Handle(ActivateUserCommand request, CancellationToken cancellationToken)
        {
            var Output = new AbstractViewModel();

            var UserToActivate =
                await _context.User
                    .FindAsync(request.ID);

            if (UserToActivate == null)
            {
                Output.status = false;
                Output.lstError.Add("User not found");
                return Output;
            }

            try
            {
                UserToActivate.IsActive = true;
                await _context.SaveChangesAsync();
                Output.status = true;
            }
            catch
            {
                Output.lstError.Add("Error while deleting the user");
            }

            return Output;
        }
    }
}
