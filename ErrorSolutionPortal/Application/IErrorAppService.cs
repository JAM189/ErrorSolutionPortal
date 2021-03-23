using ErrorSolutionPortal.Entities;
using ErrorSolutionPortal.Models;
using System;
using System.Threading.Tasks;

namespace ErrorSolutionPortal.Application
{
    public interface IErrorAppService
         : ICrudAppService<ErrorSolution, Guid>
    {
        Task<SearchResult> Get(SearchModel search);
    }
}
