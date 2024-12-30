using System.ComponentModel.DataAnnotations;

namespace UsrsMVCApp.DTO
{
    public class UserSignUpDTO
    {
        [StringLength(50, MinimumLength =2, ErrorMessage ="Username should be between 2 and 50 characters.")]
        public string? Username { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Firstname should be between 2 and 50 characters.")]
        public string? Firstname { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Lastname should be between 2 and 50 characters.")]
        public string? Lastname { get; set;}

        [StringLength(50, ErrorMessage = "Email should be 50 characters.")]
        [EmailAddress(ErrorMessage ="Email address is not valid.")]
        public string? Email { get; set; }

        [StringLength(36, ErrorMessage ="Password Length should not exceed 36 characters")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?\d)(?=.*?\W).{8,}$", ErrorMessage ="Password must contain " + 
            "at least 8 characters, one lowercase, one uppercase, one special, one digit and one special character")]
        public string? Password { get; set; }

        [StringLength(15, MinimumLength =10, ErrorMessage ="Phonenumber should be between 10 and 15 characters")]
        public string? PhoneNumber { get; set; }

        [StringLength(50, ErrorMessage = "Institution should not exceed 50 characters")]
        public string? Institution { get; set; }

        [StringLength(50, ErrorMessage = "UserRole should not exceed 50 characters")]
        public string? UserRole { get; set; }
    }
}
