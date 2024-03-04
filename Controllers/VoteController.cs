using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SINNI_Football.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Vote(Document context)
        {
            if (context is not null && !string.IsNullOrEmpty(context.Token))
            {
                var actor = AuthController._users.FirstOrDefault(x => x.Key == context.Token).Value;

                if (actor != null)
                {
                    var doc = Document.Parse(context.Value.ToString());
                    return Ok();
                }
                return Unauthorized("TOKEN_INVALID");
            }
            return Unauthorized("TOKEN_INVALID");
        }
    }
}
