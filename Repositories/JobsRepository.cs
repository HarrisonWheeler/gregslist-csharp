using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using gregslist_api.Models;

namespace gregslist_api.Controllers
{
  public class JobsRepository
  {
    private readonly IDbConnection _db;

    public JobsRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Job> Get()
    {
      string sql = "SELECT * FROM jobs";
      return _db.Query<Job>(sql);
    }
  }
}