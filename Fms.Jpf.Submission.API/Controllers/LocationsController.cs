namespace Fms.Jpf.Submission.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    using Fms.Jpf.Submission.DAL.Models;
    using Fms.Jpf.Submission.Service.Contracts;

    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService _locationService;
        public LocationsController(ILocationService locationService)
        {
            this._locationService = locationService;
        }

        [HttpGet]
        public IEnumerable<Location> Get()
        {
            return this._locationService.GetAllLocations();
        }
    }
}
