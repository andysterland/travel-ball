using FlightApi;
using NUnit.Framework;
using System.IO;

namespace FlightTests
{
    public class AirportInfoTests
    {
        public AirportService m_aiportFactory;

        [SetUp]
        public void Setup()
        {
            m_aiportFactory = new AirportService();
            var dataPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "AirportData.csv");
            m_aiportFactory.Configure(dataPath);
        }

        [Test]
        public void TestLookup()
        {
            var airport = m_aiportFactory.GetAirport("LHR");
            Assert.That(airport, Is.Not.Null);
            Assert.That(airport.IATA, Is.EqualTo("LHR"));
            Assert.Pass();
        }
    }
}