using Nancy;
using CarDealership.Objects;
using System.Collections.Generic;

namespace CarDealership
{
  public class HomeModule: NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => View["index.cshtml"];
      Get["/view_all_cars"] = _ => {
        List<Car> allCars = Car.GetAllCars();
        return View["/view_all_cars.cshtml",allCars];
      };
      Post["/car_added"] = _ => {
        Car newCar = new Car (Request.Form["new-make-model"], Request.Form["new-price"], Request.Form["new-miles"]);
        newCar.SaveCar();
        return View["car_added.cshtml", newCar];
      };
      Post["/car_cleared"] = _ => {
        Car.ClearAll();
        return View["car_cleared.cshtml"];
      };
    }
  }
}
