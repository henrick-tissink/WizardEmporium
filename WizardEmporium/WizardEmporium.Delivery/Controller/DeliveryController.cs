using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WizardEmporium.Common.SharedController;
using WizardEmporium.Common.SharedResponse;
using WizardEmporium.Deliveries.Dto;
using WizardEmporium.Deliveries.Service;
using WizardEmporium.Deliveries.ServiceObject;

namespace WizardEmporium.Deliveries.Controller
{
    [Route("api/[controller]")]
    public class DeliveryController : BaseController
    {
        private readonly IDeliveryService service;

        public DeliveryController(IDeliveryService service)
        {
            this.service = service;
        }

        [HttpGet("All")]
        [ProducesResponseType(typeof(ValueResponse<IEnumerable<DeliveryDto>, DeliveryServiceResponseCode>), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> GetDeliveries() =>
            PrepareResponse(await service.GetDeliveriesAsync());

        [HttpGet("{deliveryId}")]
        [ProducesResponseType(typeof(ValueResponse<DeliveryDto, DeliveryServiceResponseCode>), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> GetDelivery(int deliveryId) =>
            PrepareResponse(await service.GetDeliveryAsync(deliveryId));

        [HttpPost("Schedule")]
        [ProducesResponseType(typeof(EmptyResponse<DeliveryServiceResponseCode>), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> ScheduleDelivery(ScheduleDeliveryRequest request) =>
            PrepareResponse(await service.ScheduleDelivery(request));

        [HttpPut("Complete/{deliveryId}")]
        [ProducesResponseType(typeof(EmptyResponse<DeliveryServiceResponseCode>), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> CompleteDelivery(int deliveryId) =>
            PrepareResponse(await service.CompleteDeliveryAsync(deliveryId));
    }
}