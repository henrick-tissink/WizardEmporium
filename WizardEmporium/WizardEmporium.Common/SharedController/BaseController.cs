using Microsoft.AspNetCore.Mvc;
using System;
using WizardEmporium.Common.Constant;
using WizardEmporium.Common.SharedResponse;

namespace WizardEmporium.Common.SharedController
{
    public abstract class BaseController : Controller
    {
        protected IActionResult PrepareResponse<T>(BaseResponse<T> response) where T : Enum =>
            response.IsSuccessful
                ? Ok(response)
                : (IActionResult)BadRequest(new ErrorResponse(response.GlobalResponseCode));
    }
}
