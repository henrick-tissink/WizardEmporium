using System.Threading.Tasks;
using WizardEmporium.Common.SharedResponse;
using WizardEmporium.User.ServiceObject;

namespace WizardEmporium.User.Service
{
    public interface IAccountService
    {
        Task<EmptyResponse> AdminRegisterAsync(AdminRegisterRequest request);
        Task<EmptyResponse> DeleteAccountAsync(int accountId);
        Task<LoginResponse> LoginAsync(LoginRequest request);
        Task<PaymentResponse> ProcessPaymentAsync(PaymentRequest request);
        Task<EmptyResponse> SuspendAccountAsync(int accountId);
        Task<EmptyResponse> UnsuspendAccountAsync(int accountId);
        Task<EmptyResponse> UserRegisterAsync(UserRegisterRequest request);
    }
}