using System.Collections.Generic;
using System.Linq;
using Fms.Jpf.Submission.DAL.Contracts;
using Fms.Jpf.Submission.DAL.Implementations;
using Fms.Jpf.Submission.DAL.Models;
using Fms.Jpf.Submission.Service.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Fms.Jpf.Submission.Service.Tests
{
    /// <summary>
    /// Latitude and Longitude numbers pulled from https://www.latlong.net/
    /// These tests are pretty simple as the LocationService is simply pulling
    /// data from the repository and passing them along, but if there were object
    /// maps or some sort of business logic, these tests may be more valuable.
    /// For the most part, I'm simply showing these as examples of how to test
    /// this particular part of the system.
    /// </summary>
    [TestClass]
    public class LocationServiceTests
    {
        private ILocationRepository _locationRepository;
        private ILocationService _locationService;

        [TestInitialize]
        public void Initialize()
        {
            this._locationRepository = new FakeLocationRepository();
            this._locationService = new LocationService(this._locationRepository);
        }

        [TestMethod]
        public void GetAllLocations_NoInput_ReturnsTheCountThatTheFakeRepoProvides()
        {
            // Arrange taken care of in Initialize

            // Act...
            var result = this._locationService.GetAllLocations().ToList();

            // Assert
            Assert.AreEqual(4, result.Count);
        }

        [TestMethod]
        public void GetAllLocations_NoInput_ReturnsTheCountThatTempRepoProvides()
        {
            // Arrange
            ILocationRepository locationRepo = new TempLocationRepo();
            ILocationService service = new LocationService(locationRepo);

            // Act
            var result = service.GetAllLocations().ToList();

            // Assert
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void GetAllLocations_NoInput_ReturnsTheCountUsingMoq()
        {
            var locationList = new List<Location>
            {
                new Location { Id = 1, Name = "Denver, CO", Latitude = 39.739235f, Longitude = -104.990250f }
            };

            var moqRepo = new Mock<ILocationRepository>();
            moqRepo.Setup(loc => loc.GetAll()).Returns(locationList);

            var locationService = new LocationService(moqRepo.Object);

            // Act
            var result = locationService.GetAllLocations().ToList();

            // Assert
            Assert.AreEqual(1, result.Count);
        }
    }

    /// <summary>
    /// No need to pull in Moq if we don't need to...
    /// But we can - as shown in the method above
    /// </summary>
    public class TempLocationRepo : ILocationRepository
    {
        public IEnumerable<Location> GetAll()
        {
            return new List<Location>
            {
                new Location {Id = 1, Name = "Salem, VA", Latitude = 37.293377f, Longitude = -80.054665f},
                new Location {Id = 2, Name = "Fort Madison, IA", Latitude = 40.630020f, Longitude = -91.313492f}
            };
        }
    }
}
