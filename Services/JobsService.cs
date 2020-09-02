using System.Collections.Generic;
using gregslist_api.Models;

namespace gregslist_api.Controllers
{
  public class JobsService
  {
    private readonly JobsRepository _repo;

    public JobsService(JobsRepository repo)
    {
      _repo = repo;
    }

    public IEnumerable<Job> Get()
    {
      return _repo.Get();
    }


  }
}