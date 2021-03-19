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
    }
}
