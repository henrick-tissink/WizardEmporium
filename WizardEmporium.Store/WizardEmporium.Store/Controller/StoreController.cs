using Microsoft.AspNetCore.Mvc;
using WizardEmporium.Common.SharedController;

namespace WizardEmporium.Store.Controller
{
    public class StoreController : BaseController
    {
        [HttpGet("Items")]
        public IActionResult GetItems()
        {
            return null;
        }

        [HttpGet("Item/{itemId}")]
        public IActionResult GetItem(int itemId)
        {
            return null;
        }

        [HttpPost("Buy/{itemId}")]
        public IActionResult BuyItem()
        {
            return null;
        }
    }
}
