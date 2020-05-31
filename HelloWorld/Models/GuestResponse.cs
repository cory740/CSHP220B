using System.ComponentModel.DataAnnotations;

namespace HelloWorld.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Please enter your phone")]
        public string Email { get; set; }

        [Phone]
        [Required(ErrorMessage = "Please enter your email")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please enter your attendance status")]
        public bool? WillAttend { get; set; }
    }
}