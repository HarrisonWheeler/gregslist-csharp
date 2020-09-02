using System;
using System.Collections.Generic;
using gregslist_api.Models;
using gregslist_api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace gregslist_api.Services
{
  public class CarsService
  {
    private readonly CarsRepository _repo;

    public CarsService(CarsRepository repo)
    {
      _repo = repo;
    }

    public IEnumerable<Car> Get()
    {
      return _repo.Get();
    }

    public IEnumerable<Car> Get(string userId)
    {
      return _repo.Get(userId);
    }

    public Car GetById(int id)
    {
      Car foundCar = _repo.GetById(id);
      if (foundCar == null)
      {
        throw new Exception("Invalid car Id");
      }
      return foundCar;
    }
    public Car Create(Car newCar)
    {
      return _repo.Create(newCar);
    }

    public string Delete(string userId, int id)
    {
      GetById(id);
      bool delorted = _repo.Delete(userId, id);
      if (!delorted)
      {
        throw new Exception("Oops ALL BERRIES You are not the owner of this car");
      }
      return "Delorted!";
    }

    public Car Update(Car updatedCar)
    {
      Car foundCar = GetById(updatedCar.Id);
      updatedCar.Make = updatedCar.Make != null ? updatedCar.Make : foundCar.Make;
      updatedCar.Model = updatedCar.Model != null ? updatedCar.Model : foundCar.Model;
      updatedCar.Year = updatedCar.Year != 0 ? updatedCar.Year : foundCar.Year;
      updatedCar.Price = updatedCar.Price != 0 ? updatedCar.Price : foundCar.Price;
      updatedCar.Description = updatedCar.Description != null ? updatedCar.Description : foundCar.Description;
      updatedCar.ImgUrl = updatedCar.ImgUrl != null ? updatedCar.ImgUrl : foundCar.ImgUrl;
      // DO ALL THE OTHER THINGS
      bool updated = _repo.Update(updatedCar);
      if (!updated)
      {
        throw new Exception("Oops ALL BERRIES You are not the owner of this car");
      }
      return updatedCar;
    }
  }
}