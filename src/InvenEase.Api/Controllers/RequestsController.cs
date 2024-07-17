using Microsoft.AspNetCore.Mvc;

namespace InvenEase.Api.Controllers;

[Route("[controller]")]
public class RequestsController : ApiController
{
    [HttpGet]
    public IActionResult ListRequests()
    {
        return Ok(Array.Empty<string>());
    }
}