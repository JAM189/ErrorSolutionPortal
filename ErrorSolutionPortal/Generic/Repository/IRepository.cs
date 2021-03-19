namespace ErrorSolutionPortal
{
    public interface IRepository<TEntity, TPrimaryKey>
        : ICrudRepository<TEntity, TPrimaryKey> where TEntity : class
    { }
}
