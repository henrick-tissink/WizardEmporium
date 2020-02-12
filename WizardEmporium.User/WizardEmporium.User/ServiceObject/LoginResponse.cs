using WizardEmporium.Common.Constant;
using WizardEmporium.Common.SharedResponse;

namespace WizardEmporium.User.ServiceObject
{
    public enum LoginResponseCode
    {
        InvalidPasswordOrUsername = GlobalResponseCode.InvalidPasswordOrUsername,
        AccountHasBeenSuspended = GlobalResponseCode.AccountHasBeenSuspended,
        None = GlobalResponseCode.None
    }

    public class LoginResponse : BaseResponse<LoginResponseCode>
    {
        public long AccountId { get; set; }
        public long RoleId { get; set; }
        public string Username { get; set; }

        public LoginResponse(LoginResponseCode responseCode = LoginResponseCode.None) : base(responseCode) { }
        public static implicit operator LoginResponse(LoginResponseCode responseCode) => new LoginResponse(responseCode);
    }
}
