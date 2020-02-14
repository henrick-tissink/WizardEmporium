using System.Threading.Tasks;
using WizardEmporium.Common.SharedResponse;
using WizardEmporium.User.ServiceObject;

namespace WizardEmporium.User.Service
{
    public interface IAccountService
    {
        Task<EmptyResponse<AccountServiceResponseCode>> AdminRegisterAsync(AdminRegisterRequest request);
        Task<EmptyResponse<AccountServiceResponseCode>> DeleteAccountAsync(int accountId);
        Task<LoginResponse> LoginAsync(LoginRequest request);
        Task<PaymentResponse> ProcessPaymentAsync(PaymentRequest request);
        Task<EmptyResponse<AccountServiceResponseCode>> SuspendAccountAsync(int accountId);
        Task<EmptyResponse<AccountServiceResponseCode>> UnsuspendAccountAsync(int accountId);
        Task<EmptyResponse<AccountServiceResponseCode>> UserRegisterAsync(UserRegisterRequest request);
    }
}