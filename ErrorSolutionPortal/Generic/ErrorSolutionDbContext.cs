using ErrorSolutionPortal.Entities;
using Microsoft.EntityFrameworkCore;

namespace ErrorSolutionPortal
{
    public class ErrorSolutionDbContext
        : DbContext
    {
        public ErrorSolutionDbContext(
            DbContextOptions<ErrorSolutionDbContext> options
            ) : base(options)
        { }

        public DbSet<ErrorSolution> Errors { get; set; }
    }
}
