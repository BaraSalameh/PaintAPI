using Application.Admin.MappingProfiles;
using Application.Admin.Queries.SystemLanguageQueries;
using Application.Common.Entities;
using AutoMapper;
using DataAccess.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Application.Admin.Handlers.SystemLanguageHandlers
{
    public class SystemLanguageListQueryHandler : IRequestHandler<ListQuery<SLLQ_SystemLanguageListQuery>, ListQuery_Response<SLLQ_SystemLanguageListQuery>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public SystemLanguageListQueryHandler(IAppDbContext context)
        {
            _context = context;
            _mapper = new SystemLanguageMappingProfiles().SystemLanguageListQueryHandler();
        }

        public async Task<ListQuery_Response<SLLQ_SystemLanguageListQuery>> Handle(ListQuery<SLLQ_SystemLanguageListQuery> request, CancellationToken cancellationToken)
        {
            var Output = new ListQuery_Response<SLLQ_SystemLanguageListQuery>();
            Expression<Func<System_Language, bool>> Filter = f => true;

            if (!string.IsNullOrEmpty(request.Search))
            {
                var StrSearch = request.Search;
                Filter = f =>
                    f.Key!.Contains(StrSearch) ||
                    f.English!.Contains(StrSearch) ||
                    f.Arabic!.Contains(StrSearch) ||
                    f.Turkish!.Contains(StrSearch);
            }

            var ResultFromDB =
                _context.System_Language
                    .Where(Filter);

            Output.Items =
                await _mapper.ProjectTo<SLLQ_SystemLanguageListQuery>(
                    ResultFromDB.Skip((int)(request.PageNumber * request.PageSize)!).Take((int)request.PageSize!)
                ).ToListAsync();
            Output.RowCount = Output.Items.Count();

            return Output;
        }
    }
}
