using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/**
 * A View component is more like a partial view
 * It doesn't respond to HTTP requests like get or post
 * It's going to be embedded inside of of some other view
 * That will simply hand it off to go render this view component
 * ASP.Net Core will call the method Invoke when that happens
 * 
 * Viewcomponents work a little more like the MVC Framework inside of ASP.NET CORE
 * you have an action method that builds a model and you pass that model to a view
 * by returning some view result.
 */
namespace OdeToFood.ViewComponents
{
    public class RestaurantCountViewComponent
        : ViewComponent
    {
        private readonly IRestaurantData restaurantData;

        public RestaurantCountViewComponent(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public IViewComponentResult Invoke()
        {
            var count = restaurantData.GetCountOfRestaurants();

            return View(count);
        }
    }
}
