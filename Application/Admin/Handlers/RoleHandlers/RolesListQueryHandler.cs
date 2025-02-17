using Application.Admin.MappingProfiles;
using Application.Admin.Queries.RoleQueries;
using Application.Common.Entities;
using AutoMapper;
using DataAccess.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Application.Admin.Handlers.RoleHandlers
{
    public class RolesListQueryHandler : IRequestHandler<ListQuery<RLQ_RolesListQuery>, ListQuery_Response<RLQ_RolesListQuery>> 
    { 

        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public RolesListQueryHandler(IAppDbContext context)
        {
            _context = context;
            _mapper = new RoleMappingProfiles().RolesListQueryHandler();
        }

        public async Task<ListQuery_Response<RLQ_RolesListQuery>> Handle(ListQuery<RLQ_RolesListQuery> request, CancellationToken cancellationToken)
        {
            var Output = new ListQuery_Response<RLQ_RolesListQuery>();
            Expression<Func<Role, bool>> Filter = f => true;

            if (!string.IsNullOrEmpty(request.Search))
            {
                var StrSearch = request.Search;
                Filter = f =>
                    f.Name!.Contains(StrSearch);
            }

            var ResultFromDB =
                _context.Role
                    .Where(Filter);

            Output.Items =
                await _mapper.ProjectTo<RLQ_RolesListQuery>(
                    ResultFromDB.Skip((int)(request.PageNumber * request.PageSize)!).Take((int)request.PageSize!)
                ).ToListAsync();
            Output.RowCount = Output.Items.Count();

            return Output;
        }
    }
}
