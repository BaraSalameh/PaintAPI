using Application.Common.Entities;
using MediatR;

namespace Application.Admin.Commands.SystemLanguageCommands
{
    public class AddEditSystemLanguageCommand : IRequest<AbstractViewModel>
    {
        public int? ID { get; set; }
        public string Key { get; set; }
        public string English { get; set; }
        public string? Arabic { get; set; }
        public string? Turkish { get; set; }
    }
}
