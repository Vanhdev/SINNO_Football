using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SINNI_Football.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        [HttpPost("Get-all")]
        public async Task<IActionResult> GetAll(Document context)
        {
            if (context is not null && !string.IsNullOrEmpty(context.Token))
            {
                var actor = AuthController._users.FirstOrDefault(x => x.Key == context.Token.Trim()).Value;

                if (actor != null)
                {
                    var doc = DB.Accounts.Select(x => x.Role != "Admin").ToList();
                    return Ok(doc);
                }
                return Unauthorized("TOKEN_INVALID");
            }
            return Unauthorized("TOKEN_INVALID");
        }
        [HttpPost("Get-info")]
        public async Task<IActionResult> GetInfo(Document context)
        {
            if (context is not null && !string.IsNullOrEmpty(context.Token))
            {
                var actor = AuthController._users.FirstOrDefault(x => x.Key == context.Token.Trim()).Value;

                if (actor != null)
                {
                    var doc = DB.Accounts.Find(actor.Username);
                    actor.Copy(doc);
                    actor.Password = null;
                    actor.Token = context.Token;
                    return Ok(actor);
                }
                return Unauthorized("TOKEN_INVALID");
            }
            return Unauthorized("TOKEN_INVALID");
        }
    }
}
