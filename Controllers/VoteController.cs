using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace SINNI_Football.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        [HttpPost("Get-active-vote")]
        public async Task<IActionResult> GetVote(Document context)
        {
            if (context is not null && !string.IsNullOrEmpty(context.Token))
            {
                var actor = AuthController._users.FirstOrDefault(x => x.Key == context.Token.Trim()).Value;

                if (actor != null)
                {
                    var vote = DB.Votes.Select(x => x.Active).FirstOrDefault();
                    return Ok(vote.ToString());
                }
                return Unauthorized("TOKEN_INVALID");
            }
            return Unauthorized("TOKEN_INVALID");
        }
    }
}
