using Microsoft.AspNetCore.Mvc;
using ParksClient.Models;
using System.Collections.Generic;
using System;
using Newtonsoft.Json.Linq;

namespace ParksClient.Controllers;

public class ParksController: Controller
{
  public IActionResult Index()
  {
    List<Park> parks = Park.GetParks();
    return View(parks);
  }

  public IActionResult Details(int id)
  {
    Park park = Park.GetDetails(id);
    return View(park);
  }

  public ActionResult Create()
  {
    return View();
  }

  [HttpPost]
  public ActionResult Create(Park park)
  {
    Park.Post(park);
    return RedirectToAction("Index");
  }

  public ActionResult Edit(int id)
  {
    Park park = Park.GetDetails(id);
    return View(park);
  }

  [HttpPost]
  public ActionResult Edit(Park park)
  {
    Park.Put(park);
    return RedirectToAction("Details", new { id = park.ParkId });
  }

  public ActionResult Delete(int id)
  {
    Park park = Park.GetDetails(id);
    return View(park);
  }

  [HttpPost, ActionName("Delete")]
  public ActionResult DeleteConfirmed(int id)
  {
    Park.Delete(id);
    return RedirectToAction("Index");
  }

}

