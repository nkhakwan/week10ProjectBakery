using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Places.Models;

namespace Places.Controllers
{
  public class PlacesController : Controller
  {
    [HttpGet("/places/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/places")]
    public ActionResult Create(string cityName, string myPicture, string companion, string myJournal)
    {
      City myCity = new City(cityName, myPicture, companion, myJournal);
      return RedirectToAction("Index");
    }

    [HttpGet("/places")]
    public ActionResult Index()
    {
      List<City> allCities = City.GetAll();
      return View(allCities);
    }
    
    [HttpGet("/places/{Id}")]
    public ActionResult Show(int Id)
    {
      City foundPlace = City.FindMyPlace(Id);
      return View(foundPlace);
    }

    [HttpPost("/places/delete")]
    public ActionResult DeleteAll()
    {
      City.ClearAll();
      return View();
    }

    [HttpPost("/places/delete/{Id}")]
    public ActionResult DeleteOnePlace(int Id)
    {
      
      City.DeleteMyPlace(Id);
      return View();
    }
  }
}


