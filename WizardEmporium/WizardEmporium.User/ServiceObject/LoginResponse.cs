using WizardEmporium.Common.SharedResponse;
using WizardEmporium.User.Service;

namespace WizardEmporium.User.ServiceObject
{
    public class LoginResponse : BaseResponse<AccountServiceResponseCode>
    {
        public long AccountId { get; set; }
        public long RoleId { get; set; }
        public string Username { get; set; }

        public LoginResponse(AccountServiceResponseCode responseCode = default) : base(responseCode) { }
        public static implicit operator LoginResponse(AccountServiceResponseCode responseCode) => new LoginResponse(responseCode);
    }
}
