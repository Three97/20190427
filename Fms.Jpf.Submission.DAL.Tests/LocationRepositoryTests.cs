using System.Linq;
using Fms.Jpf.Submission.DAL.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fms.Jpf.Submission.DAL.Tests
{
    [TestClass]
    public class LocationRepositoryTests
    {
        [TestMethod]
        public void GetAll_NoInput_ReturnsTheExpectedObjectCount()
        {
            // Arrange
            var repo = new FakeLocationRepository();

            // Act
            var result = repo.GetAll().ToList();

            // Assert
            Assert.AreEqual(4, result.Count);
        }

        [TestMethod]
        public void GetAll_NoInput_TheThirdObjectIsCorrect()
        {
            // Arrange
            var repo = new FakeLocationRepository();

            // Act
            var result = repo.GetAll().ToList();
            var thirdObject = result[2];

            // Assert
            Assert.AreEqual(3, thirdObject.Id);
            Assert.AreEqual(thirdObject.Name, "Saint John, NB (Canada)");
            Assert.AreEqual(45.272812f, thirdObject.Latitude);
            Assert.AreEqual(-66.063026f, thirdObject.Longitude);
        }
    }
}
