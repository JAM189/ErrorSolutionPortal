using ErrorSolutionPortal;

namespace ErrorSolutionPortal
{
    public class UnitOfWork : IUnitOfWork
    {
        public ErrorSolutionDbContext Context { get; }

        public UnitOfWork(ErrorSolutionDbContext context)
        {
            Context = context;
        }

        public void Commit()
        {
            Context.SaveChanges();
        }
    }
}
