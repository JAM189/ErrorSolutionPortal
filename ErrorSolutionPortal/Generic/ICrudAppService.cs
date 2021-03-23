using System.Collections.Generic;
using System.Threading.Tasks;

namespace ErrorSolutionPortal
{
    public interface ICrudAppService<TDto, TPrimaryKey>
    {
        Task<TDto> Get(TPrimaryKey id);

        Task Create(TDto tDto);

        Task Update(TDto tDto);

        Task Delete(TPrimaryKey id);
    }
}
