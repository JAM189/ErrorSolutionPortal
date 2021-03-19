using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErrorSolutionPortal
{
    public abstract class Entity
        : Entity<int>
    { }

    public abstract class Entity<TPrimaryKey> 
        : IEntity<TPrimaryKey>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public TPrimaryKey Id { get; set; }
    }

    public interface IEntity<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }
}
