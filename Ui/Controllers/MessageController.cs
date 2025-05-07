using Microsoft.AspNetCore.Mvc;

namespace Ui.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
