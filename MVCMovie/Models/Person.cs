using System;
using System.ComponentModel.DataAnnotations;

namespace MVCMovie.Models
{
    public class PersonClass
    {
        [Key]
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
    }
}
