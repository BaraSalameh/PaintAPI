using Application.Common.Entities;
using MediatR;

namespace Application.Admin.Commands.UserCommands
{
    public class AddEditUserCommand : IRequest<AbstractViewModel>
    {
        public int? ID { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public string? BackupEmail { get; set; }
        public string? Phone { get; set; }
        public string? BackupPhone { get; set; }
        public int? RoleID { get; set; }
    }
}
