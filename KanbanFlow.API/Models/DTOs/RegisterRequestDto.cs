using System.ComponentModel.DataAnnotations;

namespace KanbanFlow.API.Models.DTOs
{
    public class RegisterRequestDto
    {
        [Required]
        [RegularExpression(@"[A-Za-z]+\s+[A-Za-z]+", ErrorMessage = "User name must only contain letters and white space. Ex: John Smith")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string[] Roles { get; set; }
    }
}
