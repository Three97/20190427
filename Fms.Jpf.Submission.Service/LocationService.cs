using System;
using System.Collections.Generic;
using Fms.Jpf.Submission.DAL.Contracts;
using Fms.Jpf.Submission.DAL.Models;
using Fms.Jpf.Submission.Service.Contracts;

namespace Fms.Jpf.Submission.Service
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            this._locationRepository = locationRepository;
        }

        public IEnumerable<Location> GetAllLocations()
        {
            return this._locationRepository.GetAll();
        }
    }
}
