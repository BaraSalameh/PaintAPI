using Application.Admin.MappingProfiles;
using Application.Admin.Queries.UserQueries;
using Application.Common.Entities;
using AutoMapper;
using DataAccess.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Application.Admin.Handlers.UserHandlers
{
    public class UsersListQueryHandler : IRequestHandler<ListQuery<ULQ_UsersListQuery>, ListQuery_Response<ULQ_UsersListQuery>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public UsersListQueryHandler(IAppDbContext context)
        {
            _context = context;
            _mapper = new UserMappingProfiles().UsersListQueryHandler();
        }

        public async Task<ListQuery_Response<ULQ_UsersListQuery>> Handle(ListQuery<ULQ_UsersListQuery> request, CancellationToken cancellationToken)
        {
            var Output = new ListQuery_Response<ULQ_UsersListQuery>();
            Expression<Func<User, bool>> Filter = f => true;

            if (!string.IsNullOrEmpty(request.Search))
            {
                var StrSearch = request.Search;
                Filter = f =>
                    f.Firstname!.Contains(StrSearch) ||
                    f.Lastname!.Contains(StrSearch) ||
                    f.Username!.Contains(StrSearch);
            }

            var ResultFromDB =
                _context.User
                .Where(u => u.IsActive == true)
                .Where(Filter);

            Output.Items =
                await _mapper.ProjectTo<ULQ_UsersListQuery>(
                    ResultFromDB.Skip((int)(request.PageNumber * request.PageSize)!).Take((int)request.PageSize!)
                ).ToListAsync();
            Output.RowCount = Output.Items.Count();

            return Output;
        }
    }
}
