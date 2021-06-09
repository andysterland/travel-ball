using FlightObjectModel;
using NUnit.Framework;

namespace FlightTests
{
    public class AirportInfoTests
    {
        public AirportService m_aiportFactory;

        [SetUp]
        public void Setup()
        {
            m_aiportFactory = new AirportService();
        }

        [Test]
        public void TestLookup()
        {
            var airport = m_aiportFactory.GetAirport("LHR");
            Assert.IsNotNull(airport);
            Assert.AreEqual(airport.IATA, "LHR");
            Assert.Pass();
        }
    }
}