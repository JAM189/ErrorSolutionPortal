using ErrorSolutionPortal.Entities;
using System;

namespace ErrorSolutionPortal.Application
{
    public interface IErrorAppService
         : ICrudAppService<ErrorSolution, Guid>
    {
        //search get
    }
}
