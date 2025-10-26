using Microsoft.AspNetCore.Mvc;

namespace Conference.Api.Controllers;

public class ValuesController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok("get all test route");
    }
}