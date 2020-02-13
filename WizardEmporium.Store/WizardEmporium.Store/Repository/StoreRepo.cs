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

        public async Task<IEnumerable<MagicItemDto>> GetMagicItemsAsync(IEnumerable<int> itemIds) =>
            await GetConnectionAsync(con => con.QueryAsync<MagicItemDto>(@"
SELECT MagicItemId, Description, Price, Quantity
FROM INVENTORY
WHERE MagicItemId IN @itemIds", new { itemIds }));

        public async Task InsertMagicItemsAsync(IEnumerable<MagicItemDto> items) =>
            await GetConnectionAsync(con => con.ExecuteAsync(@"
INSERT INTO Inventory(Description, Price, Quantity)
VALUES(@Description, @Price, @Quantity)", items));

        public async Task UpdateMagicItemsAsync(IEnumerable<MagicItemDto> items)
        {
            // Done this way for SQLite
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

        public async Task DeleteMagicItemsAsync(IEnumerable<int> itemIds) =>
            await GetConnectionAsync(con => con.ExecuteAsync(@"
DELETE FROM Inventory
WHERE AccountId in @itemIds", new { itemIds }));

        public async Task InsertOrderAsync(int magicItem, int quantity) =>
            await GetConnectionAsync(con => con.ExecuteAsync(@"
INSERT INTO Orders(MagicItemId, Quantity)
VALUES(@magicItem, @quantity)", new { magicItem, quantity }));

        public async Task<IEnumerable<MagicItemOrderDto>> GetOrdersAsync() =>
            await GetConnectionAsync(con => con.QueryAsync<MagicItemOrderDto>(@"
SELECT OrderId, MagicItemId, Quantity
FROM Orders"));

        public async Task<MagicItemOrderDto> GetOrderAsync(int orderId) =>
            await GetConnectionAsync(con => con.QueryFirstOrDefaultAsync<MagicItemOrderDto>(@"
SELECT OrderId, MagicItemId, Quantity
FROM Orders
WHERE OrderId = @orderId", new { orderId }));

        public async Task DeleteOrderAsync(int orderId) =>
            await GetConnectionAsync(con => con.ExecuteAsync(@"
DELETE FROM Orders
WHERE OrderId = @orderId", new { orderId }));

        public async Task ProcessOrderAsync(int orderId, MagicItemDto dto) =>
            await GetConnectionTransactionAsync((con, tran) =>
            {
                var deleteOrder = con.ExecuteAsync(@"
DELETE FROM Orders
WHERE OrderId = @orderId", new { orderId });
//Your table naming is inconsistent here with the rest of your tables. Here it is a plural whereas the rest are singular.
                var updateStore = con.ExecuteAsync(@"
UPDATE Inventory
SET Quantity = @Quantity
WHERE MagicItemId = @MagicItemId
", dto);

                return Task.WhenAll(deleteOrder, updateStore);
            });
    }
}
