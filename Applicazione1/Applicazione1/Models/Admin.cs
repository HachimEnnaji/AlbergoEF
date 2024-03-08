using System.ComponentModel.DataAnnotations;

namespace Applicazione1.Models
{
    public class admin
    {
        [Key]
        public int IdAdmin { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
