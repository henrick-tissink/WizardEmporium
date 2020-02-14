using System.ComponentModel.DataAnnotations;

namespace WizardEmporium.User.ServiceObject
{
    public class AdminRegisterRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int RoleId { get; set; }
    }
}
