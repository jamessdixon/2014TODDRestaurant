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
    public class NonRestaurantController : ODataController
    {
        private RestaurantChickenEntities db = new RestaurantChickenEntities();

        // GET odata/NonRestaurant
        [Queryable]
        public IQueryable<NonRestaurant> GetNonRestaurant()
        {
            return db.NonRestaurants;
        }

        // GET odata/NonRestaurant(3081)
        [Queryable]
        public SingleResult<NonRestaurant> GetNonRestaurant([FromODataUri] int key)
        {
            return SingleResult.Create(db.NonRestaurants.Where(nonrestaurant => nonrestaurant.Id == key));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NonRestaurantExists(int key)
        {
            return db.NonRestaurants.Count(e => e.Id == key) > 0;
        }
    }
}
