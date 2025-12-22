using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  
    public class BuggyController : BaseApiController
    {
        [HttpGet("auth")]
        public IActionResult GetAuth()
        {
            return Unauthorized();
        }

         [HttpGet("not-found")]
        public IActionResult GetNotFound()
        {
            return NotFound();
        }

         [HttpGet("server-error")]
        public IActionResult GetServerError()
        {
            throw  new Exception("This is a server Error");
        }

          [HttpGet("bad-request")]
        public IActionResult GetBadRequest()
        {
           return BadRequest("This was not a good Request");
        }


        [Authorize(Roles = "Admin")]
        [HttpGet("admin-secret")]
        public ActionResult<string> GetSecretAdmin()
        {
            return Ok("Only admins should see this");
        }
        
    } 
}
