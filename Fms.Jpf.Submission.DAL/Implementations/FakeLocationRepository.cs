using System.Collections.Generic;
using Fms.Jpf.Submission.DAL.Contracts;
using Fms.Jpf.Submission.DAL.Models;

namespace Fms.Jpf.Submission.DAL.Implementations
{
    public class FakeLocationRepository : ILocationRepository
    {
        public IEnumerable<Location> GetAll()
        {
            return GetAllLocations();
        }
        private IEnumerable<Location> GetAllLocations()
        {
            // values gathered from https://www.latlong.net/
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