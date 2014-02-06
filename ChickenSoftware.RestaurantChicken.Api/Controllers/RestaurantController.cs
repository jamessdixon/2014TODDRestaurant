using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using ChickenSoftware.RestraurantChicken.Data;

namespace ChickenSoftware.RestaurantChicken.Api.Controllers
{
    public class RestaurantController : ODataController
    {
        private RestaurantChickenEntities db = new RestaurantChickenEntities();

        // GET odata/Restaurant
        [Queryable]
        public IQueryable<Restaurant> GetRestaurant()
        {
            return db.Restaurants;
        }

        // GET odata/Restaurant(5)
        [Queryable]
        public SingleResult<Restaurant> GetRestaurant([FromODataUri] int key)
        {
            return SingleResult.Create(db.Restaurants.Where(restaurant => restaurant.Id == key));
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RestaurantExists(int key)
        {
            return db.Restaurants.Count(e => e.Id == key) > 0;
        }
    }
}
