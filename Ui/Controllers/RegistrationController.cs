using Bl.Api;
using Bl.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ui.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : Controller
    {

        IBlRegistration bl;
        IBlEvent blEvent;
        IBlStudent blStudent;
        public RegistrationController(IBl blManager)
        {
            bl = blManager.registration;
            blEvent = blManager.events;
            blStudent = blManager.students;
        }
        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(bl.GetAll());
        }
        [Route("GetRegisteredStudentsForEventId")]
        [HttpGet]
        public IActionResult GetRegisteredStudentsForEventId(int eId)
        {
            return Ok(bl.GetRegisteredStudentsForEventId(eId));
        }
        [Route("Add")]
        [HttpPost]
        public void Add([FromBody] BlRegistration registration) 
        {
            if (blEvent.GetEventById(registration.EventId) != null &&
                blStudent.GetById(registration.StudentId) != null)
                bl.AddRegistration(registration);
        }  
    }
}
