using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WizardEmporium.Common.SharedController;
using WizardEmporium.Deliveries.Service;
using WizardEmporium.Deliveries.ServiceObject;

namespace WizardEmporium.Deliveries.Controller
{
    public class DeliveryController : BaseController
    {
        private readonly IDeliveryService service;

        public DeliveryController(IDeliveryService service)
        {
            this.service = service;
        }

        [HttpGet("Deliveries")]
        public async Task<IActionResult> GetDeliveries() =>
            PrepareResponse(await service.GetDeliveriesAsync());

        [HttpPost("Schedule")]
        public async Task<IActionResult> ScheduleDelivery(ScheduleDeliveryRequest request) =>
            PrepareResponse(await service.ScheduleDelivery(request));

        [HttpPut("Complete/{deliveryId}")]
        public async Task<IActionResult> CompleteDelivery(int deliveryId) =>
            PrepareResponse(await service.CompleteDeliveryAsync(deliveryId));
    }
}