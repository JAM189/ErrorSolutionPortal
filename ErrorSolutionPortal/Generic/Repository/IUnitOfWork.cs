using ErrorSolutionPortal;

namespace ErrorSolutionPortal
{
    public interface IUnitOfWork
    {
        ErrorSolutionDbContext Context { get; }

        void Commit();
    }
}
