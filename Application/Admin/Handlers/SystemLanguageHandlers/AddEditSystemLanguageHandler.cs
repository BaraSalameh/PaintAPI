using Application.Admin.Commands.SystemLanguageCommands;
using Application.Admin.MappingProfiles;
using Application.Admin.Validations;
using Application.Common.Entities;
using Application.Common.Services;
using AutoMapper;
using DataAccess.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Admin.Handlers.SystemLanguageHandlers
{
    public class AddEditSystemLanguageHandler : IRequestHandler<AddEditSystemLanguageCommand, AbstractViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly UserService _userService;
        private readonly IMapper _mapper;

        public AddEditSystemLanguageHandler(IAppDbContext context, UserService userService)
        {
            _context = context;
            _userService = userService;
            _mapper = new SystemLanguageMappingProfiles().AddEditSystemLanguageCommandHandler();
        }

        public async Task<AbstractViewModel> Handle(AddEditSystemLanguageCommand request, CancellationToken cancellationToken)
        {
            var Output = new AbstractViewModel();
            var ResultToDB = _mapper.Map<System_Language>(request);

            Output.lstError = ResultToDB.ValidateSystemLanguage(Output.lstError);
            if (Output.lstError.Count > 0)
            {
                return Output;
            }


            if (request.ID == null)
            {
                ResultToDB.CreatedBy = int.Parse(_userService.GetUserId());
                _context.System_Language.Add(ResultToDB);
            }
            else
            {
                var oldSystemLanguage =
                    await _context.System_Language
                        .FindAsync(request.ID);

                if (oldSystemLanguage == null)
                {
                    Output.lstError.Add("SystemLanguage not found");
                    return Output;
                }

                _mapper.Map(request, oldSystemLanguage);
            }

            try
            {
                await _context.SaveChangesAsync();
                Output.status = true;
            }
            catch
            {
                Output.lstError.Add("Error while adding/updating system language");
            }

            return Output;
        }
    }
}
