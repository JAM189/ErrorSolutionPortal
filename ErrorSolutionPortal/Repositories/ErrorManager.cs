using ErrorSolutionPortal.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorSolutionPortal.Repositories
{
    public class ErrorManager
        : RepositoryAsync<Entities.ErrorSolution, Guid>,
          IErrorManager
    {
        public ErrorManager(
             IUnitOfWork unitOfWork
            ) : base(unitOfWork)
        { }

        public async Task<IEnumerable<ErrorSolution>> Get(string spName, params object[] parameters)
        {
            var result = unitOfWork.Context.Set<ErrorSolution>().FromSqlRaw($"EXECUTE {spName}", parameters);
            return result.AsEnumerable<ErrorSolution>();
        }
    }
}
