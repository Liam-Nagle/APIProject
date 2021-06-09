using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace APIProjectTest
{
    class GetTopChartsFromCountryTests
    {
        GetTopChartsFromCountryService _getTopChartsFromCountryService;

        [OneTimeSetUp]
        public async Task SetUpAsync()
        {
            _getTopChartsFromCountryService = new GetTopChartsFromCountryService();
            await _getTopChartsFromCountryService.MakeGetTopChartsFromCountry("UK", 3);
        }

        [Test]
        public void StatusIs200()
        {
            Assert.That(_getTopChartsFromCountryService.CallManager.StatusDescription, Is.EqualTo("OK"));
        }
    }
}
