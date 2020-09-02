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

    public Job Create(Job newJob)
    {
      string sql = @"INSERT INTO jobs
      (company, description, hours, rate, userId)
      VALUES
      (@company, @description, @hours, @rate, @userID);
      SELECT LAST_INSERT_ID();";
      newJob.Id = _db.ExecuteScalar<int>(sql, newJob);
      return newJob;
    }
  }
}