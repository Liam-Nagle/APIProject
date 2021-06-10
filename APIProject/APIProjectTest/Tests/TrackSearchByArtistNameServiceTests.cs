﻿using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace APIProjectTest
{
    public class HappyPathTrackSearchServiceTests
    {
        TrackSearchByArtistNameService _trackSearchService;

        [OneTimeSetUp]
        public async Task SetUpAsync()
        {
            _trackSearchService = new TrackSearchByArtistNameService();
            await _trackSearchService.MakeHighestRatedTrackByArtistRequestAsync("Iron Maiden", 3);
        }

        [Category("Happy Path")]
        [Test]
        public void WhenValidArtistSearched_StatusReturnedIsOK()
        {
            Assert.That(_trackSearchService.CallManager.StatusDescription, Is.EqualTo("OK"));
        }
        [Category("Happy Path")]
        [Test]
        public void WhenValidArtistSearched_StatusCodeReturnedIs200()
        {
            Assert.That(_trackSearchService.SingleTrackDTO.Response.message.header.status_code, Is.EqualTo(200));
        }
        [Category("Happy Path")]
        [Test]
        public void WhenValidArtistSearched_StatusCodeReturnedIs200_Alternative()
        {
            Assert.That(_trackSearchService.Json_Response["message"]["header"]["status_code"].ToString(), Is.EqualTo("200"));
        }
        [Category("Happy Path")]
        [Test]
        public void QueryThatRequestsTopThreeSongsReturned_GivesArrayCount3()
        {
            Assert.That(_trackSearchService.SingleTrackDTO.Response.message.body.track_list.Length, Is.EqualTo(3));
        }
        [Category("Happy Path")]
        [Test]
        public void ValidArtistRequestForFirstSong_ReturnsValidSongId()
        {
            Assert.That(_trackSearchService.SingleTrackDTO.Response.message.body.track_list[0].track.track_id, Is.EqualTo(83855348));
        }
        [Category("Happy Path")]
        [Test]
        public void ValidArtistRequestForFirstSong_ReturnsValidSongTitleForRequest()
        {
            Assert.That(_trackSearchService.SingleTrackDTO.Response.message.body.track_list[0].track.track_name, Is.EqualTo("The Educated Fool"));
        }
        [Category("Happy Path")]
        [Test]
        public void ValidArtistRequestForFirstSong_ReturnsValidAlbumnId()
        {
            Assert.That(_trackSearchService.SingleTrackDTO.Response.message.body.track_list[0].track.album_id , Is.EqualTo(20845893));
        }
        [Category("Happy Path")]
        [Test]
        public void ValidArtistRequestForFirstSong_ReturnsValidAlbumnName()
        {
            Assert.That(_trackSearchService.SingleTrackDTO.Response.message.body.track_list[0].track.album_name, Is.EqualTo("Virtual XI"));
        }
        [Category("Happy Path")]
        [Test]
        public void ValidArtistRequestForFirstSong_ReturnsValidArtistId()
        {
            Assert.That(_trackSearchService.SingleTrackDTO.Response.message.body.track_list[0].track.artist_id, Is.EqualTo(6781));
        }
        [Category("Happy Path")]
        [Test]
        public void ValidArtistRequestForFirstSong_ReturnsValidArtistName()
        {
            Assert.That(_trackSearchService.SingleTrackDTO.Response.message.body.track_list[0].track.artist_name, Is.EqualTo("Iron Maiden"));
        }
        [Category("Happy Path")]
        [Test]
        public void ValidArtistRequestForFirstSong_ReturnsValidCommonTrackId()
        {
            Assert.That(_trackSearchService.SingleTrackDTO.Response.message.body.track_list[0].track.commontrack_id, Is.EqualTo(805145));
        }
        [Category("Happy Path")]
        [Test]
        public void ValidArtistRequestForFirstSong_ReturnsHasLyricsValue1IndicatingSongHasLyrics()
        {
            Assert.That(_trackSearchService.SingleTrackDTO.Response.message.body.track_list[0].track.has_lyrics, Is.EqualTo(1));
        }
        [Category("Happy Path")]
        [Test]
        public void ValidArtistRequestForFirstSong_ReturnsHasRichSyncValue0IndicatingSongHasNoRichSync()
        {
            Assert.That(_trackSearchService.SingleTrackDTO.Response.message.body.track_list[0].track.has_richsync, Is.EqualTo(0));
        }
        [Category("Happy Path")]
        [Test]
        public void ValidArtistRequestForFirstSong_ReturnsHasSubtitlesValue1IndicatingSongHasSubtitles()
        {
            Assert.That(_trackSearchService.SingleTrackDTO.Response.message.body.track_list[0].track.has_subtitles, Is.EqualTo(1));
        }
        [Category("Happy Path")]
        [Test]
        public void ValidArtistRequestForSecondSong_ReturnsValidSongTitleForRequest()
        {
            Assert.That(_trackSearchService.SingleTrackDTO.Response.message.body.track_list[1].track.track_name, Is.EqualTo("A Yellow Sky"));
        }
        [Category("Happy Path")]
        [Test]
        public void ValidArtistRequestForThirdSong_ReturnsValidSongTitleForRequest()
        {
            Assert.That(_trackSearchService.SingleTrackDTO.Response.message.body.track_list[2].track.track_name, Is.EqualTo("Bleed It Out"));
        }
    }
    public class SadPathTrackSearchServiceTests
    {
        TrackSearchByArtistNameService _trackSearchService;

        [OneTimeSetUp]
        public async Task SetUpAsync()
        {
            _trackSearchService = new TrackSearchByArtistNameService();
            await _trackSearchService.MakeHighestRatedTrackByArtistRequestAsync("Iron Maiden", Int32.MaxValue);
        }

        [Category("Sad Path")]
        [Test]
        public void WhenInvalidArtistSearched_StatusCodeStillEquals200()
        {
            Assert.That(_trackSearchService.SingleTrackDTO.Response.message.header.status_code, Is.EqualTo(200));
        }
        [Category("Sad Path")]
        [Test]
        public void WhenInvalidArtistSearched_StatusCodeStillIsOK()
        {
            Assert.That(_trackSearchService.CallManager.StatusDescription, Is.EqualTo("OK"));
        }
        [Category("Sad Path")]
        [Test]
        public void LengthOfArrayGreaterThan100()
        {
            Assert.That(_trackSearchService.SingleTrackDTO.Response.message.body.track_list.Length , Is.EqualTo(100));
        }
    }
}
