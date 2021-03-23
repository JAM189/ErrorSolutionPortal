using ErrorSolutionPortal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ErrorSolutionPortal.Repositories
{
    public interface IErrorManager
         : IRepository<Entities.ErrorSolution, Guid>
    {
        Task<IEnumerable<ErrorSolution>> Get(string spName, params object[] parameters);
    }
}
