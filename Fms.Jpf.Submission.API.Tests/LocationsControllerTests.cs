namespace Fms.Jpf.Submission.API.Tests
{
    using System.Linq;

    using Fms.Jpf.Submission.API.Controllers;
    using Fms.Jpf.Submission.DAL.Contracts;
    using Fms.Jpf.Submission.DAL.Implementations;
    using Fms.Jpf.Submission.Service;
    using Fms.Jpf.Submission.Service.Contracts;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LocationsControllerTests
    {
        private LocationsController _controller;
        private ILocationService _locationService;
        private ILocationRepository _locationRepository;

        [TestInitialize]
        public void Initialize()
        {
            // in this case, we can use the same repo for testing purposes..
            this._locationRepository = new FakeLocationRepository();
            // there's nothing special about the LocationService, so we can
            // use it directly for our tests..
            this._locationService = new LocationService(this._locationRepository);
            this._controller = new LocationsController(this._locationService);
        }

        [TestMethod]
        public void Get_NoInput_ReturnsFourObjects()
        {
            // Arrange handled in [TestInitialized]

            // Act
            var actual = _controller.Get().ToList();
            
            // Assert (multiple results, so multiple asserts here)
            Assert.AreEqual(4, actual.Count);
        }

        [TestMethod]
        public void Get_NoInput_ReturnsRaleighObjectWithProperLatLong()
        {
            // Arrange handled in [TestInitialized]

            // Act
            var actual = _controller.Get().ToList();
            var expectedSecondItem = actual.First(loc => loc.Id == 2);

            // Assert (multiple results, so multiple asserts here)
            Assert.AreEqual(35.779591f, expectedSecondItem.Latitude);
            Assert.AreEqual(-78.638176f, expectedSecondItem.Longitude);
            Assert.AreEqual("Raleigh, NC", expectedSecondItem.Name);
        }
    }
}
