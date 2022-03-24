using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfosetTask.Business.Abstracts;
using InfosetTask.DataAccess;
using InfosetTask.Models;

namespace InfosetTask.Business.Concrete
{
    public class RestaurantManager:IRestaurantService
    {
        private RestaurantDal restaurantDal;
        public RestaurantManager(RestaurantDal _restaurantDal)
        {
            this.restaurantDal = _restaurantDal;
        }
        public List<Restaurant> getList()
        {
            return restaurantDal.List();
        }
        public List<Restaurant> getList(double lat,double lng)
        {
            List<Restaurant> list = new List<Restaurant>();
            List<Restaurant> calculateList = new List<Restaurant>();

            List<Restaurant> returnList= new List<Restaurant>();

            list = restaurantDal.List();

            for (int i = 0; i < list.Count; i++)
            {
                var km =distance(lat, list[i].latitude, lng, list[i].longitude);
                if (km<10)
                {
                    km = Math.Round(km, 2);
                    list[i].distance = km;
                    calculateList.Add(list[i]);
                }
            }

            calculateList = calculateList.OrderBy(q => q.distance).ToList();
            for (int j = 0; j < 5; j++)
            {
                returnList.Add(calculateList[j]);
            }
            return restaurantDal.List(returnList);
        }
        static double toRadians(
            double angleIn10thofaDegree)
        {
            // Angle in 10th
            // of a degree
            return (angleIn10thofaDegree *
                    Math.PI) / 180;
        }
        public static double distance(double lat1,
            double lat2,
            double lon1,
            double lon2)
        {

            lon1 = toRadians(lon1);
            lon2 = toRadians(lon2);
            lat1 = toRadians(lat1);
            lat2 = toRadians(lat2);

            double dlon = lon2 - lon1;
            double dlat = lat2 - lat1;
            double a = Math.Pow(Math.Sin(dlat / 2), 2) +
                       Math.Cos(lat1) * Math.Cos(lat2) *
                       Math.Pow(Math.Sin(dlon / 2), 2);

            double c = 2 * Math.Asin(Math.Sqrt(a));

            double r = 6371;

            return (c * r);
        }

      
    }
}

