using System;

namespace ErrorSolutionPortal.Repositories
{
    public interface IErrorManager
         : IRepository<Entities.ErrorSolution, Guid>
    {
    }
}