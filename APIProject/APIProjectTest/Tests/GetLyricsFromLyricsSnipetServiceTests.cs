using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace APIProjectTest.Tests
{
    class GetLyricsFromLyricsSnipetServiceTests
    {
        GetLyricsFromLyricsSnipetService _lyricsSnipetService;

        [OneTimeSetUp]
        public async Task SetUpAsync()
        {
            _lyricsSnipetService = new GetLyricsFromLyricsSnipetService();
            await _lyricsSnipetService.MakeGetLyricsByLyricSnipetAsync("Backbeat, the word is on the street That the fire in your heart is out");
        }

        [Test]
        public void StatusIs200()
        {
            Assert.That(_lyricsSnipetService.CallManager.StatusDescription, Is.EqualTo("OK"));
        }
    }
}
