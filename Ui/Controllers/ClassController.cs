using Bl.Api;
using Microsoft.AspNetCore.Mvc;

namespace Ui.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : Controller
    {
        IBlClass bl;
        public ClassController(IBl blManager)
        {
            this.bl = blManager.Class;
        }

        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAll(int id)
        {
            return Ok(bl.GetClassEvents(id));
        }
    }
}
