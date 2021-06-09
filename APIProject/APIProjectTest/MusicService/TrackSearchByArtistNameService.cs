using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIProjectTest
{
    class TrackSearchByArtistNameService
    {
        public CallManager CallManager { get; set; }
        public JObject Json_Response { get; set; }
        public DTO<TrackResponse> SingleTrackDTO { get; set; }
        public string TrackResponse { get; set; }

        public TrackSearchByArtistNameService()
        {
            CallManager = new CallManager();
            SingleTrackDTO = new DTO<TrackResponse>();
        }
        public async Task MakeHighestRatedTrackByArtistRequestAsync(string artistName, int numSongs)
        {
            TrackResponse = await CallManager.MakeHighestRatedTrackByArtistRequestAsync(artistName, numSongs);

            Json_Response = JObject.Parse(TrackResponse);

            SingleTrackDTO.DeserializeResponse(TrackResponse);
        }
    }
}
