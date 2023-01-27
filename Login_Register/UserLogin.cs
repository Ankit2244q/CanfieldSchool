using System.ComponentModel.DataAnnotations;

namespace CanfieldSchool.Login_Register
{
    public class UserLogin
    {

        public int Id { get; set; }
        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string  ? Password { get; set; }    
    }
}
