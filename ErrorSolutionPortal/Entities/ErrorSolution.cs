using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorSolutionPortal.Entities
{
    public class ErrorSolution
        : Entity<Guid>
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Key]
        //public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Solution { get; set; }
    }
}
