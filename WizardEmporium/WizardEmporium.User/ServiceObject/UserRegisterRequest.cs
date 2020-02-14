using System.ComponentModel.DataAnnotations;

namespace WizardEmporium.User.ServiceObject
{
    public class UserRegisterRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
