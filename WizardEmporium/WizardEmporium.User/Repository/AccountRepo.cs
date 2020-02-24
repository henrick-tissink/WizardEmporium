using Dapper;
using System.Threading.Tasks;
using WizardEmporium.Common.SharedRepository;
using WizardEmporium.User.Dto;

namespace WizardEmporium.User.Repository
{
    public class AccountRepo : BaseRepo, IAccountRepo
    {
        public AccountRepo(string connectionString) : base(connectionString) { }

        public async Task InsertAccountAsync(string username, string passwordHash, int roleId) =>
            await GetConnectionAsync(con => con.ExecuteAsync(@"
INSERT INTO Account(Username, PasswordHash, RoleId) 
VALUES(@username, @passwordHash, @roleId)", new { username, passwordHash, roleId }));

        public async Task<AccountDto> FindAccountAsync(string username, string passwordHash) =>
            await GetConnectionAsync(con => con.QueryFirstOrDefaultAsync<AccountDto>(@"
SELECT AccountId, RoleId, Username, Suspended
FROM Account
WHERE Username = @username
AND PasswordHash = @passwordHash", new { username, passwordHash }));

        public async Task<AccountDto> FindAccountAsync(int accountId) =>
            await GetConnectionAsync(con => con.QueryFirstOrDefaultAsync<AccountDto>(@"
SELECT AccountId, RoleId, Username, Suspended
FROM Account
WHERE AccountId = @accountId", new { accountId }));

        public async Task DeleteAccountAsync(int accountId) =>
            await GetConnectionAsync(con => con.ExecuteAsync(@"
DELETE FROM Account
WHERE AccountId = @accountId", new { accountId }));

        public async Task<int> UpdateAccountAsync(int accountId, bool suspended) =>
            await GetConnectionAsync(con => con.ExecuteScalarAsync<int>(@"
UPDATE Account
SET Suspended = @suspended
WHERE AccountId = @accoutId", new { accountId, suspended }));
    }
}
