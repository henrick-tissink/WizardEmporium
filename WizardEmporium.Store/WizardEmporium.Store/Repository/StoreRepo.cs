using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WizardEmporium.Common.SharedRepository;
using WizardEmporium.Store.Dto;

namespace WizardEmporium.Store.Repository
{
    public class StoreRepo : BaseRepo, IStoreRepo
    {
        public StoreRepo(string connectionString) : base(connectionString) { }

        public async Task<IEnumerable<MagicItemDto>> GetMagicItemsAsync() =>
            await GetConnectionAsync(con => con.QueryAsync<MagicItemDto>(@"
SELECT MagicItemId, Description, Price, Quantity
FROM INVENTORY"));

        public async Task InsertMagicItemsAsync(IEnumerable<MagicItemDto> items)
        {
            await GetConnectionAsync(con => con.ExecuteAsync(@"
INSERT INTO Inventory(Description, Price, Quantity)
VALUES(@Description, @Price, @Quantity)", items));
        }

        public async Task UpdateMagicItemsAsync(IEnumerable<MagicItemDto> items)
        {
            foreach (var item in items)
            {
                await GetConnectionAsync(con => con.ExecuteAsync(@"
UPDATE Inventory
SET
    Description = @Description,
    Price = @Price
    Quantity = @Quantity
WHERE
    MagicItemId = @MagicItemId
", item));
            }
        }

        public async Task DeleteMagicItemsAsync(IEnumerable<int> itemIds)
        {
            await GetConnectionAsync(con => con.ExecuteAsync(@"
DELETE FROM Inventory
WHERE AccountId in @itemIds", new { itemIds }));
        }

        public async Task InsertOrderAsync(MagicItemOrderDto dto)
        {
            await GetConnectionAsync(con => con.ExecuteAsync(@"
INSERT INTO Orders(MagicItemId, Quantity)
VALUES(@MagicItemId, @Quantity)", dto));
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            await GetConnectionAsync(con => con.ExecuteAsync(@"
DELETE FROM Orders
WHERE OrderId = @orderId", new { orderId }));
        }
    }
}
