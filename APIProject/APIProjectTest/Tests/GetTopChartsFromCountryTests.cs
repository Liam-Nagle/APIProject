using NUnit.Framework;
using System;
using System.Linq;
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
            await _getTopChartsFromCountryService.MakeGetTopChartsFromCountry(Countries.GB, 3);
        }

        [Category("Happy path")]
        [Test]
        public void StatusIs200()
        {
            Assert.That(_getTopChartsFromCountryService.CallManager.StatusDescription, Is.EqualTo("OK"));
        }
        
        [Test]
        public void StatusIs200Alt1()
        {
            Assert.That(_getTopChartsFromCountryService.Json_Response["message"]["header"]["status_code"].ToString(), Is.EqualTo("200"));
        }

        [Test]
        public void ReturnsCorrectNumberOfSongs()
        {
            Assert.That(_getTopChartsFromCountryService.TopChartDTO.Response.message.body.track_list.Length, Is.EqualTo(3));
        }

        [Test]
        public void MethodReturnsAType()
        {
            Assert.That(_getTopChartsFromCountryService.TopChartDTO.Response.message.body.track_list, Is.TypeOf<Track_List[]>());
        }

        [Test]
        public void MethodReturnsTrackNameeOfTypeString()
        {
            Assert.That( _getTopChartsFromCountryService.TopChartDTO.Response.message.body.track_list[0].track.track_name, Is.TypeOf<string>());
            Assert.That(_getTopChartsFromCountryService.TopChartDTO.Response.message.body.track_list[1].track.track_name, Is.TypeOf<string>());
            Assert.That(_getTopChartsFromCountryService.TopChartDTO.Response.message.body.track_list[2].track.track_name, Is.TypeOf<string>());
        }

        [Test]
        public void MethodReturnsCorrectTrackName()
        {
            Assert.That(_getTopChartsFromCountryService.TopChartDTO.Response.message.body.track_list[0].track.track_name, Is.EqualTo("Our Song"));
            Assert.That(_getTopChartsFromCountryService.TopChartDTO.Response.message.body.track_list[1].track.track_name, Is.EqualTo("Heartbreak Anthem"));
            Assert.That(_getTopChartsFromCountryService.TopChartDTO.Response.message.body.track_list[2].track.track_name, Is.EqualTo("By Your Side (feat. Tom Grennan)"));
        }

        [Test]
        public void MethodReturnsArtistNameeOfTypeString()
        {
            Assert.That(_getTopChartsFromCountryService.TopChartDTO.Response.message.body.track_list[0].track.artist_name, Is.TypeOf<string>());
            Assert.That(_getTopChartsFromCountryService.TopChartDTO.Response.message.body.track_list[1].track.artist_name, Is.TypeOf<string>());
            Assert.That(_getTopChartsFromCountryService.TopChartDTO.Response.message.body.track_list[2].track.artist_name, Is.TypeOf<string>());
        }

        [Test]
        public void MethodReturnsCorrectArtistName()
        {
            Assert.That(_getTopChartsFromCountryService.TopChartDTO.Response.message.body.track_list[0].track.artist_name, Is.EqualTo("Anne-Marie feat. Niall Horan"));
            Assert.That(_getTopChartsFromCountryService.TopChartDTO.Response.message.body.track_list[1].track.artist_name, Is.EqualTo("Galantis"));
            Assert.That(_getTopChartsFromCountryService.TopChartDTO.Response.message.body.track_list[2].track.artist_name, Is.EqualTo("Calvin Harris feat. Tom Grennan"));
        }

        [Test]
        public void MethodReturnsTrackRatingOfTypeInt()
        {
            Assert.That(_getTopChartsFromCountryService.TopChartDTO.Response.message.body.track_list[0].track.track_rating, Is.TypeOf<int>());
            Assert.That(_getTopChartsFromCountryService.TopChartDTO.Response.message.body.track_list[1].track.track_rating, Is.TypeOf<int>());
            Assert.That(_getTopChartsFromCountryService.TopChartDTO.Response.message.body.track_list[2].track.track_rating, Is.TypeOf<int>());
        }

        [Test]
        public void MethodReturnsCorrectTrackRating()
        {
            Assert.That(_getTopChartsFromCountryService.TopChartDTO.Response.message.body.track_list[0].track.track_rating, Is.EqualTo(99));
            Assert.That(_getTopChartsFromCountryService.TopChartDTO.Response.message.body.track_list[1].track.track_rating, Is.EqualTo(99));
            Assert.That(_getTopChartsFromCountryService.TopChartDTO.Response.message.body.track_list[2].track.track_rating, Is.EqualTo(98));
        }

        [Category("Sad Path")]
        [Test]
        public void MethodReturnsExceptionIfOutOfBoundary()
        {
            Assert.Throws<IndexOutOfRangeException>(() => _getTopChartsFromCountryService.TopChartDTO.Response.message.body.track_list[3].track.track_name.ToUpper());
            Assert.Throws<IndexOutOfRangeException>(() => _getTopChartsFromCountryService.TopChartDTO.Response.message.body.track_list[3].track.artist_name.ToUpper());
            Assert.Throws<IndexOutOfRangeException>(() => _getTopChartsFromCountryService.TopChartDTO.Response.message.body.track_list[3].track.track_rating.ToString());
        }
    }
}
