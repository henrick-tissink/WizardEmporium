namespace WizardEmporium.User.Dto
{
    public class AccountDto
    {
        public int AccountId { get; set; }
        public int RoleId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
    }
}
