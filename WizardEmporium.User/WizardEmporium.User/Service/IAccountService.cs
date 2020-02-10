using System.Threading.Tasks;
using WizardEmporium.Common.SharedResponse;
using WizardEmporium.User.ServiceObject;

namespace WizardEmporium.User.Service
{
    public interface IAccountService
    {
        Task<GeneralResponse> AdminRegisterAsync(AdminRegisterRequest request);
        Task<GeneralResponse> DeleteAccountAsync(int accountId);
        Task<LoginResponse> LoginAsync(LoginRequest request);
        Task<PaymentResponse> ProcessPaymentAsync(PaymentRequest request);
        Task<GeneralResponse> SuspendAccountAsync(int accountId);
        Task<GeneralResponse> UnsuspendAccountAsync(int accountId);
        Task<GeneralResponse> UserRegisterAsync(UserRegisterRequest request);
    }
}