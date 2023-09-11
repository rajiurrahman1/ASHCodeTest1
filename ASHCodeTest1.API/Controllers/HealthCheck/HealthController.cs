using Microsoft.AspNetCore.Mvc;

namespace ASHCodeTest1.API.Controllers.HealthCheck
{
    public class HealthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
