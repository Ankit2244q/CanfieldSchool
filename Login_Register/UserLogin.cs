using System.ComponentModel.DataAnnotations;

namespace CanfieldSchool.Login_Register
{
    public class UserLogin
    {
        [Key]
        public int Id { get; set; }

        public string? UserName { get; set; } = "Ankit";


        public string? LastName { get; set; } = "podal";

        public string? Email { get; set; } = "ankisharma864@hm.com";

        public string? Password { get; set; } = "hellooworld";
    }
}
