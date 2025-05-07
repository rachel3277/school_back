using Bl.Api;
using Bl.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ui.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    { 
     
        IBlStudent bl;
        public StudentController(IBl blManager)
        {
        this.bl = blManager.students;
        }
        [Route("AcceptStudent")]
        [HttpGet]
        public IActionResult AcceptStudent(int id, bool isAccept)
        {
            return Ok(bl.AcceptStudent(id, isAccept));
        }
        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
        return Ok(bl.GetAll());
        }
        [Route("GetAcceptedStudents")]
        [HttpGet]
        public IActionResult GetAcceptedStudents()
        {
            return Ok(bl.GetAcceptedStudents());
        }
        [Route("GetNotAcceptedStudents")]
        [HttpGet]
        public IActionResult GetNotAcceptedStudents()
        {
            return Ok(bl.GetNotAcceptedStudents());
        }
        [Route("GetSons")]
        [HttpGet]
        public IActionResult GetSons(int id)
        {
            return Ok(bl.GetSons(id));
        }
        [Route("IncreaseYear")]   
        [HttpGet] 
        public void IncreaseYear()
        {
        bl.IncreaseYear();
        }
        [Route("Update")]
        [HttpPut]
        public IActionResult Update([FromBody] BlStudent blStudent) => Ok(bl.UpdateStudent(blStudent));
        [Route("AddStudent")]
        [HttpPost]
        public void AddStudent([FromBody] BlStudent blStudent)
        {
            bl.AddStudent(blStudent);
        }
        [Route("DaleteStudentById")]
        [HttpDelete]
        public IActionResult DaleteStudentById(int id)
        {
            return Ok(bl.DeleteStudentById(id));
        }
    }
}
