using Fms.Jpf.Submission.Service.Types;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Fms.Jpf.Submission.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Location> Get()
        {
            return GetAllLocations();
        }

        /// <summary>
        /// I originally started out putting this stuff into a Service
        /// which, in turn, called a DAL/Repo project, complete with interfaces
        /// of course. That seemed like overkill, so I went with the MVP
        /// approach and am just creating the collection here. It could easily
        /// be pulled out to its own project or repo or whatever...
        /// </summary>
        /// <returns>Collection of Location objects</returns>
        private IEnumerable<Location> GetAllLocations()
        {
            var collection = new List<Location>
            {
                new Location {Id = 1, Latitude = 33.448376f, Longitude = -112.074036f, Name = "Phoenix, AZ"},
                new Location {Id = 2, Latitude = 35.779591f, Longitude = -78.638176f, Name = "Raleigh, NC"},
                new Location {Id = 3, Latitude = 45.272812f, Longitude = -66.063026f, Name = "Saint John, NB (Canada)"},
                new Location {Id = 4, Latitude = 32.715736f, Longitude = -117.161087f, Name = "San Diego, CA"}
            };
            return collection;
        }
    }
}
