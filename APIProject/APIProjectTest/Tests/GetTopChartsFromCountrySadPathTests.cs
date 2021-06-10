using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace APIProjectTest
{
    class GetTopChartsFromCountrySadPathTests
    {
        GetTopChartsFromCountryService _getTopChartsFromCountryService;

        [OneTimeSetUp]
        public async Task SetUpAsync()
        {
            _getTopChartsFromCountryService = new GetTopChartsFromCountryService();
            await _getTopChartsFromCountryService.MakeGetTopChartsFromCountry(Countries.EC, int.MaxValue);
        }

        [Test]
        public void Returns100WhenUserEntersMaxNumberOfValueNumberOfSongs()
        {
            Assert.That(_getTopChartsFromCountryService.TopChartDTO.Response.message.body.track_list.Length, Is.EqualTo(100));
        }

    }
}
