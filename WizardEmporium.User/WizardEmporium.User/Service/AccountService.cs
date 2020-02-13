using Microsoft.Extensions.Options;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WizardEmporium.Common.Constant;
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

        public async Task<EmptyResponse> UserRegisterAsync(UserRegisterRequest request)
        {
            var response = await repo.FindAccountAsync(request.Username, PasswordHash(request.Username, request.Password));

            if (response != null)
                return GlobalResponseCode.UserAlreadyExists;

            await repo.InsertAccountAsync(request.Username, PasswordHash(request.Username, request.Password), roleConfig.User);
            return GlobalResponseCode.None;
        }

        public async Task<EmptyResponse> AdminRegisterAsync(AdminRegisterRequest request)
        {
            var response = await repo.FindAccountAsync(request.Username, PasswordHash(request.Username, request.Password));

            if (response != null)
                return GlobalResponseCode.UserAlreadyExists;

            await repo.InsertAccountAsync(request.Username, PasswordHash(request.Username, request.Password), request.RoleId);
            return GlobalResponseCode.None;
        }
        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var response = await repo.FindAccountAsync(request.Username, PasswordHash(request.Username, request.Password));

            if (response == null)
                return LoginResponseCode.InvalidPasswordOrUsername;

            if (await repo.FindSuspendedAccountAsync(response.AccountId) != null)
                return LoginResponseCode.AccountHasBeenSuspended;

            return new LoginResponse
            {
                AccountId = response.AccountId,
                RoleId = response.RoleId,
                Username = response.Username
            };
        }

        public async Task<EmptyResponse> DeleteAccountAsync(int accountId) 
        {
            var response = await repo.FindAccountAsync(accountId);
            if (response == null)
                return GlobalResponseCode.UserDoesNotExist;

            await repo.DeleteAccountAsync(accountId);
            return GlobalResponseCode.None;
        }

        public async Task<EmptyResponse> SuspendAccountAsync(int accountId)
        {
            var account = await repo.FindAccountAsync(accountId);
            if (account == null)
                return GlobalResponseCode.UserDoesNotExist;

            var response = await repo.FindSuspendedAccountAsync(accountId);
            if (response.HasValue)
                return GlobalResponseCode.AccountHasBeenSuspended;

            await repo.InsertIntoSuspendedAccountAsync(accountId);
            return GlobalResponseCode.None;
        }

        public async Task<EmptyResponse> UnsuspendAccountAsync(int accountId)
        {
            var response = await repo.FindSuspendedAccountAsync(accountId);

            if (response == null)
                return GlobalResponseCode.AccountNotSuspended;

            await repo.DeleteFromSuspendedAccountAsync(accountId);
            return GlobalResponseCode.None;
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
