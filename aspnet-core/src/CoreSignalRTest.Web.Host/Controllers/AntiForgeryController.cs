using Microsoft.AspNetCore.Antiforgery;
using CoreSignalRTest.Controllers;

namespace CoreSignalRTest.Web.Host.Controllers
{
    public class AntiForgeryController : CoreSignalRTestControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
