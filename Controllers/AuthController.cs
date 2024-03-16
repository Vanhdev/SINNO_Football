using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SINNI_Football.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static Dictionary<string, Actors.Account> _users = new Dictionary<string, Actors.Account>();

        [HttpPost("Login")]
        public async Task<IActionResult> Login(Document context)
        {
            var username = context.Username.Trim();
            var password = context.Password;

            // Find and check
            var exist = DB.Accounts.Find(username);
            if (exist == null)
            {
                return Unauthorized();
            }

            var acc = Actors.Account.CreateOne(username, password, string.Empty);
            if (exist.Password != acc.Password)
            {
                return Unauthorized("PASSWORD_INVALID");
            }

            var type = Type.GetType("Actors." + exist.Role);
            var actor = Activator.CreateInstance(type) as Actors.Account;

            actor.Copy(exist);
            actor.Password = null;
            actor.Token = (username + DateTime.Now.ToString()).ToMD5();

            _users.Add(actor.Token, actor);

                return Ok(actor);
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout(Document context)
        {
            if (context is not null && !string.IsNullOrEmpty(context.Token))
            {
                var actor = _users.FirstOrDefault(x => x.Key == context.Token.Trim()).Value;

                if (actor != null)
                {
                    _users.Remove(actor.Token);
                    return Ok();
                }
                return Unauthorized("TOKEN_INVALID");
            }

            return Unauthorized("TOKEN_INVALID");
        }
    }
}
