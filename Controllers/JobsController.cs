using System;
using System.Collections.Generic;
using System.Security.Claims;
using gregslist_api.Models;
using Microsoft.AspNetCore.Authorization;
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

    [Authorize]
    [HttpPost]

    public ActionResult<Job> Create([FromBody] Job newJob)
    {
      try
      {
        Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (user == null)
        {
          throw new Exception("You must be logged in to make post a job, yo.");
        }
        newJob.UserId = user.Value;
        return Ok(_service.Create(newJob));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

  }
}