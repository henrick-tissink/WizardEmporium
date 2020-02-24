using System.Threading.Tasks;
using WizardEmporium.User.Dto;

namespace WizardEmporium.User.Repository
{
    public interface IAccountRepo
    {
        Task DeleteAccountAsync(int accountId);
        Task<AccountDto> FindAccountAsync(int accountId);
        Task<AccountDto> FindAccountAsync(string username, string passwordHash);
        Task InsertAccountAsync(string username, string passwordHash, int roleId);
        Task<int> UpdateAccountAsync(int accountId, bool suspended);
    }
}