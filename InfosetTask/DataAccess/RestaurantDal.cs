using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using InfosetTask.DataAccess.Abstracts;
using InfosetTask.Models;
using Microsoft.EntityFrameworkCore;

namespace InfosetTask.DataAccess
{
    public class RestaurantDal:IRestaurantDal<Restaurant>
    {
        private InfosetTaskContext context = new InfosetTaskContext();
        private DbSet<Restaurant> restaurantsDbSet;

        public RestaurantDal()
        {
            restaurantsDbSet = context.Set<Restaurant>();
        }

        public List<Restaurant> List()
        {
            return restaurantsDbSet.ToList();
        }

        public List<Restaurant> List(List<Restaurant> list)
        {
            return list;
        }

       

      
    }
}
