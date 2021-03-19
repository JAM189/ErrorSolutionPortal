using ErrorSolutionPortal.Entities;
using ErrorSolutionPortal.Repositories;
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
            IErrorManager errorRepo)
        {
            this.unit = unit;
            this.errorRepo = errorRepo;
        }

        public async Task Create(ErrorSolution tDto)
        {
            await errorRepo.Insert(tDto);
            unit.Commit();           
        }

        public async Task Delete(Guid id)
        {
            await errorRepo.Delete(id);
            unit.Commit();
        }

        //get() implement todo
        public Task<IEnumerable<ErrorSolution>> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<ErrorSolution> Get(Guid id)
        {
            var e = await errorRepo.GetFirstOrDefault<ErrorSolution>();
            return e;      
        }

        public async Task Update(ErrorSolution tDto)
        {
            await errorRepo.Update(tDto);
            unit.Commit();
        }
    }
}
