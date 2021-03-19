namespace ErrorSolutionPortal
{
    public class SoftDeleteEntity<TPrimaryKey>
        : Entity<TPrimaryKey>
        , ISoftDeleteEntity<TPrimaryKey>
    {
        public bool IsDeleted { get; set; }
    }

    public interface ISoftDeleteEntity<TPrimaryKey>
        : IEntity<TPrimaryKey>
    {
        bool IsDeleted { get; set; }
    }
}
