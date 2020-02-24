using Microsoft.Extensions.Options;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WizardEmporium.Common.SharedResponse;
using WizardEmporium.User.Config;
using WizardEmporium.User.Repository;
using WizardEmporium.User.ServiceObject;

namespace WizardEmporium.User.Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepo repo;
        private readonly RoleConfig roleConfig;

        public AccountService(IAccountRepo repo, IOptions<RoleConfig> roleConfig)
        {
            this.repo = repo;
            this.roleConfig = roleConfig.Value;
        }

        public async Task<EmptyResponse<AccountServiceResponseCode>> UserRegisterAsync(UserRegisterRequest request)
        {
            var response = await repo.FindAccountAsync(request.Username, PasswordHash(request.Username, request.Password));

            if (response != null)
                return AccountServiceResponseCode.AccountAlreadyExists;

            await repo.InsertAccountAsync(request.Username, PasswordHash(request.Username, request.Password), roleConfig.User);
            return AccountServiceResponseCode.Success;
        }

        public async Task<EmptyResponse<AccountServiceResponseCode>> AdminRegisterAsync(AdminRegisterRequest request)
        {
            var response = await repo.FindAccountAsync(request.Username, PasswordHash(request.Username, request.Password));

            if (response != null)
                return AccountServiceResponseCode.AccountAlreadyExists;

            await repo.InsertAccountAsync(request.Username, PasswordHash(request.Username, request.Password), request.RoleId);
            return AccountServiceResponseCode.Success;
        }
        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var response = await repo.FindAccountAsync(request.Username, PasswordHash(request.Username, request.Password));

            if (response == null)
                return AccountServiceResponseCode.InvalidPasswordOrUsername;

            if (response.Suspended)
                return AccountServiceResponseCode.AccountAlreadySuspended;

            return new LoginResponse
            {
                AccountId = response.AccountId,
                RoleId = response.RoleId,
                Username = response.Username
            };
        }

        public async Task<EmptyResponse<AccountServiceResponseCode>> DeleteAccountAsync(int accountId)
        {
            var response = await repo.FindAccountAsync(accountId);
            if (response == null)
                return AccountServiceResponseCode.AccountDoesNotExist;

            await repo.DeleteAccountAsync(accountId);
            return AccountServiceResponseCode.Success;
        }

        public async Task<EmptyResponse<AccountServiceResponseCode>> SuspendAccountAsync(int accountId)
        {
            var account = await repo.FindAccountAsync(accountId);
            if (account == null)
                return AccountServiceResponseCode.AccountDoesNotExist;

            await repo.UpdateAccountAsync(account.AccountId, true);
            return AccountServiceResponseCode.Success;
        }

        public async Task<EmptyResponse<AccountServiceResponseCode>> UnsuspendAccountAsync(int accountId)
        {
            var account = await repo.FindAccountAsync(accountId);
            if (account == null)
                return AccountServiceResponseCode.AccountDoesNotExist;

            await repo.UpdateAccountAsync(accountId, false);
            return AccountServiceResponseCode.Success;
        }

        // Ignore this for now
        public async Task<PaymentResponse> ProcessPaymentAsync(PaymentRequest request)
        {
            await Task.Delay(1000);
            return new PaymentResponse();
        }

        private static string PasswordHash(string username, string password)
        {
            using var hashEngine = SHA256.Create();

            var bytes = Encoding.UTF8.GetBytes(username + password);
            var hash = hashEngine.ComputeHash(bytes, 0, bytes.Length);

            return BitConverter.ToString(hash).ToLower().Replace("-", "");
        }
    }
}
