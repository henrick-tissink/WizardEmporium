using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WizardEmporium.Common.SharedController;
using WizardEmporium.Store.Dto;

namespace WizardEmporium.Store.Controller
{
    public class StoreController : BaseController
    {
        [HttpGet("AllItems")]
        public IActionResult GetAllItems()
        {
            return null;
        }

        [HttpGet("Items")]
        public IActionResult GetItems(IEnumerable<int> itemIds)
        {
            return null;
        }

        [HttpPut("MagicItems")]
        public IActionResult UpdateItems(IEnumerable<MagicItemDto> magicItems)
        {
            return null;
        }

        [HttpPost("MagicItems")]
        public IActionResult AddItems(IEnumerable<MagicItemDto> magicItems)
        {
            return null;
        }

        [HttpDelete("MagicItems")]
        public IActionResult DeleteItems(IEnumerable<int> itemIds)
        {
            return null;
        }

        [HttpPost("Buy/{magicItemId}")]
        public IActionResult BuyItem(int magicItemId, [FromQuery]int accountId)
        {
            return null;
        }

        [HttpPost("Order")]
        public IActionResult OrderItems(IEnumerable<MagicItemOrderDto> magicItemOrders)
        {
            return null;
        }

        [HttpGet("Orders")]
        public IActionResult GetOrders()
        {
            return null;
        }

        [HttpPut("ProcessOrders")]
        public IActionResult ProcessOrders(IEnumerable<int> orderIds)
        {
            return null;
        }
    }
}
