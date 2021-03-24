using ErrorSolutionPortal.Entities;
using ErrorSolutionPortal.Models;
using ErrorSolutionPortal.Repositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ErrorSolutionPortal.Application
{
    public class ErrorAppService
        : IErrorAppService
    {
        private readonly IUnitOfWork unit;
        private readonly IErrorManager errorRepo;

        public ErrorAppService(
            IUnitOfWork unit,
            IErrorManager errorRepo
            )
        {
            this.unit = unit;
            this.errorRepo = errorRepo;
        }

        public async Task<SearchResult> Get(SearchModel search)
        {
            var searchResult = new SearchResult();

            var startParam = new SqlParameter("@Start", search.start);
            var pageSizeParam = new SqlParameter("@PageSize", search.length);
            var keywordParam = new SqlParameter("@Keyword", search.Keyword ?? string.Empty);
            var sortDirParam = new SqlParameter("@SortDir", search.SortDir ?? string.Empty);
            var sortColumnParam = new SqlParameter("@SortColumn", search.SortColumn ?? string.Empty);

            var errors = await errorRepo.Get(
                "[dbo].[GetErrors] @Start, @PageSize, @Keyword, @SortDir, @SortColumn",
                startParam,
                pageSizeParam,
                keywordParam,
                sortDirParam,
                sortColumnParam);

            searchResult.Data = errors;

            return searchResult;
        }

        public async Task<ErrorSolution> Get(Guid id)
        {
            var e = await errorRepo.GetByProp(x => x.Id == id);
            return e;
        }

        public async Task Create(ErrorSolution tDto)
        {
            await errorRepo.Insert(tDto);
            unit.Commit();
        }

        public async Task Update(ErrorSolution tDto)
        {
            await errorRepo.Update(tDto);
            unit.Commit();
        }

        public async Task Delete(Guid id)
        {
            await errorRepo.Delete(id);
            unit.Commit();
        }
    }
}
