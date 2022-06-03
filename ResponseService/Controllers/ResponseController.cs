using Microsoft.AspNetCore.Mvc;

namespace ResponseService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ResponseController : ControllerBase
{
    [Route("{id:int}")]
    [HttpGet]
    public ActionResult GetAResponse(int id)
    {
        Random rnd = new Random();
        var rndInteger = rnd.Next(1, 101);
        if (rndInteger >= id)
        {
            System.Console.WriteLine("--> Failure - Generate a HTTP 500");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
        System.Console.WriteLine("--> Success - Generate a HTTP 200");
        return StatusCode(StatusCodes.Status200OK);
    }
}
