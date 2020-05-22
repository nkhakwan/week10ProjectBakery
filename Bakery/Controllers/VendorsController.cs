using Microsoft.AspNetCore.Mvc;
using Bakery.Models;
using System.Collections.Generic;
using System;

namespace Bakery.Controllers
{
  public class VendorController : Controller
  {
    [HttpGet("/vendors")]
    public ActionResult Index()
    {
      List<Vendor> allVendors = Vendor.GetAll();
      return View(allVendors);
    }

    [HttpGet("/vendors/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/vendors")]
    public ActionResult Create(string vendorName, string vendorDescription)
    {
      Vendor myVendor = new Vendor(vendorName, vendorDescription);
      return RedirectToAction("Index");
    }

    [HttpPost("/orders/delete")]
    public ActionResult DeleteAll()
    {
      Order.ClearAll();
      return View();
    }

    // [HttpGet("/vendors/{id}")]
    // public ActionResult Show(int id)
    // {
    //   Console.WriteLine("I am in vendors.Id");
    //   Order foundOrder = Order.Find(id);
    //   return View(foundOrder);
    // }

    [HttpGet("/vendors/{id}")]
    public ActionResult Show(int id)
    {
      Console.WriteLine("i am in vendors/id");
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendor selectedVendor = Vendor.Find(id);
      List<Order> VendorOrder = selectedVendor.Orders;
      model.Add("vendor", selectedVendor);
      model.Add("order", VendorOrder);
      return View(model);
    }

    [HttpGet("/order/new")]
    public ActionResult OrderNew()
    {
      return View();
    }

  }
}