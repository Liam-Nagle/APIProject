using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace APIProjectTest
{
    public class TrackSearchServiceTests
    {
        TrackSearchByArtistNameService _trackSearchService;

        [OneTimeSetUp]
        public async Task SetUpAsync()
        {
            _trackSearchService = new TrackSearchByArtistNameService();
            await _trackSearchService.MakeHighestRatedTrackByArtistRequestAsync("Justin Bieber", 3);
        }

        [Test]
        public void StatusIs200()
        {
            Assert.That(_trackSearchService.CallManager.StatusDescription, Is.EqualTo("OK"));
        }
    }
}
