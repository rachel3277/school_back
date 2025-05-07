using Microsoft.AspNetCore.Mvc;
using Bl.Api;
using Microsoft.AspNetCore.Mvc.Filters;
using Bl.Models;
using Dal.Models;

namespace Ui.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : Controller
    {
        IBlEvent bl;
        public EventController(IBl blManager) 
        {
            bl = blManager.events;
        }
        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAll() =>  Ok(bl.GetAll());
        [Route("GetAfterEvents")]
        [HttpGet]
        public IActionResult GetAfterEvents() => Ok(bl.GetAfterEvents());
        [Route("GetBeforeEvents")]
        [HttpGet]
        public IActionResult GetBeforeEvents() => Ok(bl.GetBeforeEvents());
        [Route("GetEventsByName")]
        [HttpGet]
        public IActionResult GetEventsByName(string name) => Ok(bl.GetEventsByName(name));
        [Route("Update")]
        [HttpPut]
        public List<BlEvent> Update([FromBody] BlEvent blEvent) => bl.UpdateEvent(blEvent);
        [Route("Add")]
        [HttpPost]
        public List<BlEvent> Add([FromBody] BlEvent blEvent) => bl.AddEvent(blEvent);
        [Route("GetEventsOfStudent")]
        [HttpPost]
        public List<BlEvent> GetEventsOfStudent([FromBody] BlStudent blStudent) => bl.GetEventsOfStudent(blStudent);
        [Route("DeleteEvent")]
        [HttpDelete]
        public List<BlEvent> DeleteEvent(int id) => bl.DeleteEventById(id);
        
    }
}
