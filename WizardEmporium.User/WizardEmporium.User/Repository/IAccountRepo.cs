using System.Threading.Tasks;
using WizardEmporium.User.Dto;

namespace WizardEmporium.User.Repository
{
    public interface IAccountRepo
    {
        Task DeleteAccountAsync(int accountId);
        Task DeleteFromSuspendedAccountAsync(int accountId);
        Task<AccountDto> FindAccountAsync(string username, string passwordHash);
        Task<AccountDto> FindAccountAsync(int accountId);
        Task<int?> FindSuspendedAccountAsync(int accountId);
        Task InsertAccountAsync(string username, string passwordHash, int roleId);
        Task<int> InsertIntoSuspendedAccountAsync(int accountId);
    }
}