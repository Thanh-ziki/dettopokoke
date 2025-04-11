using System.ComponentModel.DataAnnotations;

namespace MVCMovie.Models
{
    public class Create
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}