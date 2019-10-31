using Aircompany;
using Aircompany.Models;
using Aircompany.Planes;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace AircompanyTests.Tests
{
    [TestFixture]
    public class AirportTests
    {
        [Test]
        public void HasMilitaryTransportPlane()
        {
            Airport airport = new Airport(Runner.planes);
            Assert.IsTrue(airport.GetTransportMilitaryPlanes().ToList().All(plane => plane.TypeOfPlane == MilitaryType.TRANSPORT));
        }

        [Test]
        public void IsExpectedPlaneWithMaxPassengersCapacity()
        {
            Airport airport = new Airport(Runner.planes);
            Assert.IsTrue(airport.GetPassengerPlaneWithMaxPassengersCapacity().PassengersCapacity == airport.Planes.Max().MaxLoadCapacity);
        }
        
        [Test]
        public void NextPlaneMaxLoadCapacityIsHigherThanCurrent()
        {
            Airport airport = new Airport(Runner.planes).SortByMaxLoadCapacity();
            Assert.IsTrue(airport.Planes.ToList().
                                         Select(plane => plane.MaxLoadCapacity).
                                         SequenceEqual(airport.Planes.
                                                        OrderBy(plane => plane.MaxLoadCapacity).
                                                        Select(plane => plane.MaxLoadCapacity)));
        }
    }
}
