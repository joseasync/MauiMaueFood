using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MauiMaueBE.Api.Controllers;

[Route("identity")]
[Authorize]
public class IdentityController : ControllerBase
{
    [HttpGet]
    public async Task<JsonResult> GetAsync()
    {
        return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
    }
}
