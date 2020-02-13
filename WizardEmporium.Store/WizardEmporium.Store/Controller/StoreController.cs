using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WizardEmporium.Common.SharedController;
using WizardEmporium.Store.Dto;
using WizardEmporium.Store.Service;
using WizardEmporium.Store.ServiceObject;

namespace WizardEmporium.Store.Controller
{
    public class StoreController : BaseController
    {
        private readonly IStoreService service;

        public StoreController(IStoreService service)
        {
            this.service = service;
        }

        [HttpGet("AllItems")]
        public async Task<IActionResult> GetAllItems() => PrepareResponse(await service.GetAllStockAsync());

        [HttpGet("Items")]
        public async Task<IActionResult> GetItems(IEnumerable<int> itemIds) =>
            PrepareResponse(await service.GetStockAsync(itemIds));

        [HttpPut("MagicItems")]
        public async Task<IActionResult> UpdateItems(IEnumerable<MagicItemDto> magicItems) =>
            PrepareResponse(await service.UpdateStockAsync(magicItems));

        [HttpPost("MagicItems")]
        public async Task<IActionResult> AddItems(IEnumerable<MagicItemDto> magicItems) =>
            PrepareResponse(await service.AddStockAsync(magicItems));

        [HttpDelete("MagicItems")]
        public async Task<IActionResult> DeleteItems(IEnumerable<int> itemIds) =>
            PrepareResponse(await service.DeleteStockAsync(itemIds));

        [HttpPost("Buy/{magicItemId}")]
        public async Task<IActionResult> BuyItem(int magicItemId, [FromQuery]int accountId) =>
            PrepareResponse(await service.BuyItemAsync(magicItemId, accountId));

        [HttpPost("Order")]
        public async Task<IActionResult> OrderItems(PlaceOrderRequest request) =>
            PrepareResponse(await service.PlaceOrdersAsync(request));

        [HttpGet("Orders")]
        public async Task<IActionResult> GetOrders() =>
            PrepareResponse(await service.GetOrdersAsync());

        [HttpPut("ProcessOrders")]
        public async Task<IActionResult> ProcessOrders(int orderId) =>
            PrepareResponse(await service.ProcessOrderAsync(orderId));
    }
}
