

namespace TicketUpService.Api.Controllers
{
    public class BaseController : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        protected string GetAuthUser()
        {
            return HttpContext.User.Claims.FirstOrDefault(x => x.Type == "user")?.Value;
        }
        protected string GetAuthUserStore()
        {
            return this.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "userStore")?.Value;
        }
        protected string GetAuthUserIdentity()
        {
            return this.HttpContext.User.Identity.Name;
        } 
    }
}
