namespace ErrorSolutionPortal
{
    public abstract class RepositoryAsync<TEntity, TPrimaryKey>
        : CrudRepositoryAsync<TEntity, TPrimaryKey>,
        IRepository<TEntity, TPrimaryKey> where TEntity : class
    {
        public RepositoryAsync(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        { }
    }
}
