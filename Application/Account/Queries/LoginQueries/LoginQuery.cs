using Application.Common.Entities;
using MediatR;

namespace Application.Account.Queries.LoginQueries
{
    public class LoginQuery : IRequest<LQ_Response>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LQ_Response : AbstractViewModel
    {
        public string? token { get; set; }
        public string? Username { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
    }
}
