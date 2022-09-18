using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string  Email { get; set; }
        public Gender Gender { get; set; }
        public Department Department { get; set; }
    }
}
