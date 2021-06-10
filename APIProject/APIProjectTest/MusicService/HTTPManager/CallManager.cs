using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIProjectTest
{
    class CallManager
    {
        private readonly IRestClient _client;
        public string StatusDescription { get; set; }

        public CallManager()
        {
            _client = new RestClient(AppConfigReader.BaseUrl);
        }
        public async Task<string> MakeHighestRatedTrackByArtistRequestAsync(string artistName, int numSongs)
        {
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");

            request.Resource = $"track.search?&s_track_rating=desc&q_artist={artistName.ToLower()}&page_size={numSongs.ToString()}&apikey={AppConfigReader.APIKey}";

            var response = await _client.ExecuteAsync(request);

            StatusDescription = response.StatusDescription.ToString();

            return response.Content;
        }

        public string GetTrackIDByLyricSnipet(string lyricSnipet)
        {
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");

            request.Resource = $"track.search?&q_lyrics={lyricSnipet}&s_track_rating=desc&page_size=1&apikey={AppConfigReader.APIKey}";

            var response = _client.Execute(request);

            return response.Content;
        }

        public async Task<string> GetTrackLyricsByTrackIDAsync(int trackid)
        {
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");

            request.Resource = $"track.lyrics.get?&track_id={trackid.ToString()}&apikey={AppConfigReader.APIKey}";

            var response = await _client.ExecuteAsync(request);

            StatusDescription = response.StatusDescription.ToString();

            return response.Content;
        }

        public async Task<string> MakeGetTopChartsFromCountry(string country, int numSong)
        {
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");

            request.Resource = $"chart.tracks.get?chart_name=top&page_size={numSong.ToString()}&country={country}&apikey={AppConfigReader.APIKey}";

            var responce = await _client.ExecuteAsync(request);

            StatusDescription = responce.StatusDescription.ToString();

            return responce.Content;
        }
    }
}
