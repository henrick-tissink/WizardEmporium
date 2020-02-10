using Microsoft.AspNetCore.Mvc;
using WizardEmporium.Common.SharedResponse;

namespace WizardEmporium.Common.SharedController
{
    public abstract class BaseController : Controller
    {
        protected IActionResult PrepareResponse(BaseResponse response) =>
            response.IsSuccessful
                ? Ok(response)
                : (IActionResult)BadRequest(new ErrorResponse(response.GlobalResponseCode));
    }
}
