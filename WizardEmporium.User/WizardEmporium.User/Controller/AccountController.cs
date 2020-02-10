using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WizardEmporium.Common.Constant;
using WizardEmporium.Common.SharedController;
using WizardEmporium.Common.SharedResponse;
using WizardEmporium.Common.SharedSwaggerConfig;
using WizardEmporium.User.Service;
using WizardEmporium.User.ServiceObject;

namespace WizardEmporium.User
{
    [Route("api/[controller]")]
    public class AccountController : BaseController
    {
        private readonly IAccountService service;

        public AccountController(IAccountService service) 
        {
            this.service = service;
        }

        [ProducesResponseType(typeof(GeneralResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [DescribeErrorTypeOnResponse(typeof(GlobalResponseCode), 400)]
        [HttpPost("Register/User")]
        public async Task<IActionResult> UserRegister([FromBody]UserRegisterRequest request) =>
            PrepareResponse(await service.UserRegisterAsync(request));

        [ProducesResponseType(typeof(GeneralResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [DescribeErrorTypeOnResponse(typeof(GlobalResponseCode), 400)]
        [HttpPost("Register/Admin")]
        public async Task<IActionResult> AdminRegister([FromBody]AdminRegisterRequest request) =>
            PrepareResponse(await service.AdminRegisterAsync(request));

        [ProducesResponseType(typeof(LoginResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [DescribeErrorTypeOnResponse(typeof(LoginResponseCode), 400)]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]LoginRequest request) =>
            PrepareResponse(await service.LoginAsync(request));

        [ProducesResponseType(typeof(GeneralResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [DescribeErrorTypeOnResponse(typeof(GlobalResponseCode), 400)]
        [HttpDelete("{accountId}")]
        public async Task<IActionResult> Delete(int accountId) =>
            PrepareResponse(await service.DeleteAccountAsync(accountId));

        [ProducesResponseType(typeof(GeneralResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [DescribeErrorTypeOnResponse(typeof(GlobalResponseCode), 400)]
        [HttpPut("Suspend/{accountId}")]
        public async Task<IActionResult> Suspend(int accountId) =>
            PrepareResponse(await service.SuspendAccountAsync(accountId));

        [ProducesResponseType(typeof(GeneralResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [DescribeErrorTypeOnResponse(typeof(GlobalResponseCode), 400)]
        [HttpPut("Unsuspend/{accountId}")]
        public async Task<IActionResult> Unsuspend(int accountId) =>
            PrepareResponse(await service.UnsuspendAccountAsync(accountId));

        // IGNORED FOR NOW
        [HttpPost("ProcessPayment")]
        public async Task<IActionResult> ProcessPayment([FromBody]PaymentRequest request)
        {
            var response = await service.ProcessPaymentAsync(request);

            if (response != null)
                return Ok(response);

            return BadRequest();
        }
    }
}
