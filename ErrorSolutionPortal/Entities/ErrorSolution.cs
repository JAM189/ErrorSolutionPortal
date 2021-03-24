using System;

namespace ErrorSolutionPortal.Entities
{
    public class ErrorSolution
        : Entity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Solution { get; set; }
    }
}
