using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfosetTask.Business.Concrete;
using InfosetTask.DataAccess;

namespace InfosetTask.Controllers
{
    public class RestaurantController : Controller
    {
        private RestaurantManager restaurantManager = new RestaurantManager(new RestaurantDal());
        
        [HttpGet]
        public IActionResult Index()
        {
            var restaurantList = restaurantManager.getList();
            return View(restaurantList);
        }
        [HttpPost]
        public IActionResult Index(double lat,double lng)
        {
            var latitude = Request.Form["latitude"];
            var longitude =Request.Form["longitude"];
            StringBuilder sblat = new StringBuilder(latitude);
            sblat[2] = ',';
            StringBuilder sblong = new StringBuilder(longitude);
            sblong[2] = ',';

            latitude = sblat.ToString();
            longitude = sblong.ToString();
            double latitudeDouble = Convert.ToDouble(latitude);
            double longitudeDouble = Convert.ToDouble(longitude);
 
            var restaurantList = restaurantManager.getList(latitudeDouble,longitudeDouble);
            return View(restaurantList);
        }



    }
}
