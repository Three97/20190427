using Fms.Jpf.Submission.API.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Fms.Jpf.Submissions.API.Tests
{
    [TestClass]
    public class LocationsControllerTests
    {
        private LocationsController _controller;

        [TestInitialize]
        public void Initialize()
        {
            this._controller = new LocationsController();
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
