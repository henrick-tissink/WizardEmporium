using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WizardEmporium.Common.SharedRepository;
using WizardEmporium.Deliveries.Dto;

namespace WizardEmporium.Deliveries.Repository
{
    public class DeliveryRepo : BaseRepo, IDeliveryRepo
    {
        public DeliveryRepo(string connectionString) : base(connectionString) { }

        public Task<int> InsertDeliveryAsnc(int magicItemId, int accountId, int quantity) =>
            GetConnectionAsync(con => con.ExecuteScalarAsync<int>(@"
INSERT INTO Delivery(MagicItemId, AccountId, Quantity)
VALUES(@magicItemId, @accountID, @quantity)", new { magicItemId, accountId, quantity }));

        public Task<IEnumerable<DeliveryDto>> GetDeliveriesAsync() =>
            GetConnectionAsync(con => con.QueryAsync<DeliveryDto>(@"
SELECT DeliveryId, MagicItemId, AccountId, Quantity, Completed
FROM Delivery"));

        public Task<DeliveryDto> GetDeliveryAsync(int deliveryId) =>
            GetConnectionAsync(con => con.QueryFirstOrDefaultAsync<DeliveryDto>(@"
SELECT DeliveryId, MagicItemId, AccountId, Quantity, Completed
FROM Delivery
WHERE DeliveryId = @deliveryId", new { deliveryId }));

        public Task UpdateDeliveryAsync(DeliveryDto dto) =>
            GetConnectionAsync(con => con.ExecuteAsync(@"
UPDATE Delivery
SET
    MagicItemId = @MagicItemId
    AccountId = @AccountId
    Quantity = @Quantity
    Completed = @Completed
WHERE
    DeliveryId = @DeliveryId", dto));
    }
}
