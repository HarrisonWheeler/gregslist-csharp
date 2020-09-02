using System.Collections.Generic;
using gregslist_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace gregslist_api.Controllers
{


  [ApiController]
  [Route("api/[controller]")]

  public class JobsController : ControllerBase
  {
    private readonly JobsService _service;

    public JobsController(JobsService service)
    {
      _service = service;
    }

    [HttpGet]

    public ActionResult<IEnumerable<Job>> Get()
    {
      try
      {
        return Ok(_service.Get());
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

  }
}