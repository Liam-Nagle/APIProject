using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace APIProjectTest
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

        [Category("Happy Path")]
        [Test]
        public void StatusIsOK()
        {
            Assert.That(_lyricsSnipetService.CallManager.StatusDescription, Is.EqualTo("OK"));
        }

        [Category("Happy Path")]
        [Test]
        public void StatusIs200_JSonResponse()
        {
            Assert.That(_lyricsSnipetService.Json_Response["message"]["header"]["status_code"].ToString(), Is.EqualTo("200"));
        }

        [Category("Happy Path")]
        [Test]
        public void StatusIs200_DTO()
        {
            Assert.That(_lyricsSnipetService.LyricSnipetDTO.Response.message.header.status_code, Is.EqualTo(200));
        }

        [Category("Happy Path")]
        [Test]
        public void StatusIs200_TrackDTO()
        {
            Assert.That(_lyricsSnipetService.TrackResponseDTO.Response.message.header.status_code, Is.EqualTo(200));
        }

        [Category("Happy Path")]
        [Test]
        public void TrackResponseDTO_ReturnsCorrectTrackName()
        {
            var expected = "Wonderwall";
            Assert.That(_lyricsSnipetService.TrackResponseDTO.Response.message.body.track_list[0].track.track_name.ToLower(), Is.EqualTo(expected.ToLower()));
        }

        [Category("Happy Path")]
        [Test]
        public void TrackResponseDTO_ReturnsCorrectAlbumName()
        {
            var expected = "(What's The Story) Morning Glory?";
            Assert.That(_lyricsSnipetService.TrackResponseDTO.Response.message.body.track_list[0].track.album_name.ToLower(), Is.EqualTo(expected.ToLower()));
        }

        [Category("Happy Path")]
        [Test]
        public void TrackResponseDTO_ReturnsCorrectArtistName()
        {
            Assert.That(_lyricsSnipetService.TrackResponseDTO.Response.message.body.track_list[0].track.artist_name, Is.EqualTo("Oasis"));
        }

        [Category("Happy Path")]
        [Test]
        public void TrackResponseDTO_Returns_0_IfSongDoesntHaveExplicitLyrics()
        {
            Assert.That(_lyricsSnipetService.TrackResponseDTO.Response.message.body.track_list[0]
                .track._explicit, Is.EqualTo(0));
        }

        [Category("Happy Path")]
        [Test]
        public void LyricSnipetDTO_ReturnsCorrectLyrics()
        {
            Assert.That(_lyricsSnipetService.LyricSnipetDTO
                .Response.message.body.lyrics.lyrics_body.StartsWith("Today is gonna be the day\nThat they're gonna throw it back to you"),
                Is.True);
        }

        [Category("Happy Path")]
        [Test]
        public void LyricSnipetDTO_Returns_0_IfSongDoesntHaveExplicitLyrics()
        {
            Assert.That(_lyricsSnipetService.LyricSnipetDTO
                .Response.message.body.lyrics._explicit, Is.EqualTo(0));
        }

        [Category("Happy Path")]
        [Test]
        public void Json_Response_ReturnsCorrectLyrics()
        {
            Assert.That(_lyricsSnipetService.Json_Response["message"]["body"]["lyrics"]["lyrics_body"]
                .ToString().StartsWith("Today is gonna be the day\nThat they're gonna throw it back to you"), Is.True);
        }

        [Category("Happy Path")]
        [Test]
        public void Json_Response_Returns_0_IfSongDoesntHaveExplicitLyrics()
        {
            Assert.That(_lyricsSnipetService.Json_Response["message"]["body"]["lyrics"]["explicit"].ToString(), Is.EqualTo("0"));
        }

        [Category("Sad Path")]
        [Test]
        public void ThrowsException_WhenNoSongsContainLyrics()
        {
            var _lyricsSnipetServiceTest = new GetLyricsFromLyricsSnipetService();
            Assert.ThrowsAsync<ArgumentException>(async () => await _lyricsSnipetServiceTest.MakeGetLyricsByLyricSnipetAsync("Liam Nagle"));
        }
    }
}
