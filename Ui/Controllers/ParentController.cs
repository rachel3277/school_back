using Microsoft.AspNetCore.Mvc;
using Bl.Api;
using Bl.Models;

namespace Ui.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentController : Controller
    {
        IBlParent bl;
        public ParentController(IBl blManager)
        {
            this.bl = blManager.parents;
        }
        
        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(bl.GetAll());
        }
        [Route("GetAcceptedSons")]
        [HttpGet]
        public IActionResult GetAcceptedSons(int parentId)
        {
            return Ok(bl.GetAcceptedSons(parentId));
        }
        [Route("GetById")]
        [HttpGet]
        public IActionResult GetById(int id)
        {
            return Ok(bl.GetParentById(id));
        }
        [Route("GetNotAcceptedParents")]
        [HttpGet]
        public IActionResult GetNotAcceptedParents()
        {
            return Ok(bl.GetNotAcceptedParents());
        }
        [Route("UpdateParent")]
        [HttpPut]
        public IActionResult UpdateParent(BlParent blParent)
        {
            return Ok(bl.UpdateParent(blParent));
        }
        [Route("Add")]
        [HttpPost]
        public int Add([FromBody] BlParent blParent) => bl.AddParent(blParent);
        //[Route("DeleteExitParents")]
        //[HttpDelete]
        //public void DeleteExitParents()
        //{
        //     bl.DeleteExitParents();
        //}
        //[Route("DeleteParent")]
        //[HttpDelete]
        //public List<BlParent> DeleteParent(int id) => bl.DeleteById(id);
    }
}
