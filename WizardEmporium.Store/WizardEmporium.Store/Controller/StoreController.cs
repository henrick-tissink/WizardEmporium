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

        [HttpPut("MagicItems")]
        public IActionResult UpdateItems()
        {
            return null;
        }

        [HttpPost("MagicItems")]
        public IActionResult AddItems()
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
