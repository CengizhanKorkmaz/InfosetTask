using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfosetTask.Models;

namespace InfosetTask.Business.Abstracts
{
    public interface IRestaurantService
    {

        List<Restaurant> getList();
        List<Restaurant> getList(double lat,double lng);

    }
}
