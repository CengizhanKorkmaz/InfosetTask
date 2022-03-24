using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using InfosetTask.Models;

namespace InfosetTask.DataAccess.Abstracts
{
    public interface IRestaurantDal<Restaurant>
    {
        List<Restaurant> List();
        List<Restaurant> List(List<Restaurant> list);

    }
}
