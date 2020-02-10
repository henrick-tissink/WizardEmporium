using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WizardEmporium.Common.SharedController;

namespace WizardEmporium.Store.Controller
{
    public class StoreController : BaseController
    {
        [HttpGet("Items")]
        public IActionResult GetItems(IEnumerable<int> itemIds)
        {
            return null;
        }

        [HttpPut("Items")]
        public IActionResult UpdateItems()
        {
            return null;
        }

        [HttpDelete("Items")]
        public IActionResult DeleteItems(IEnumerable<int> itemIds)
        {
            return null;
        }

        [HttpPost("Buy/{itemId}")]
        public IActionResult BuyItem(int itemId, [FromQuery]int accountId)
        {
            return null;
        }

        [HttpPost("Order")]
        public IActionResult OrderItems()
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
