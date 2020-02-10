using WizardEmporium.Common.Constant;
using WizardEmporium.Common.SharedResponse;

namespace WizardEmporium.User.ServiceObject
{
    public enum LoginResponseCode
    {
        InvalidPasswordOrUsername = GlobalResponseCode.InvalidPasswordOrUsername,
        AccountHasBeenSuspended = GlobalResponseCode.AccountHasBeenSuspended
    }

    public class LoginResponse : BaseResponse
    {
        public long AccountId { get; set; }
        public long RoleId { get; set; }
        public string Username { get; set; }

        public override GlobalResponseCode GlobalResponseCode => (GlobalResponseCode)ResponseCode;

        private LoginResponseCode ResponseCode { get; }

        public LoginResponse() { }

        public LoginResponse(LoginResponseCode responseCode)
        {
            ResponseCode = responseCode;
        }

        public static implicit operator LoginResponse(LoginResponseCode responseCode) => new LoginResponse(responseCode);
    }
}
