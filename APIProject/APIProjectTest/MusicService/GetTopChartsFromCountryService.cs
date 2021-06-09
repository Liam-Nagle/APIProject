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
    class GetTopChartsFromCountryService
    {
        public CallManager CallManager { get; set; }
        public JObject Json_Response { get; set; }
        public DTO<TrackResponse> TopChartDTO { get; set; }
        public string TopChartResponse { get; set; }

        public GetTopChartsFromCountryService()
        {
            CallManager = new CallManager();
            TopChartDTO = new DTO<TrackResponse>();
        }

        public async Task MakeGetTopChartsFromCountry(string country, int numSong)
        {
            TopChartResponse = await CallManager.MakeGetTopChartsFromCountry(country, numSong);

            Json_Response = JObject.Parse(TopChartResponse);

            TopChartDTO.DeserializeResponse(TopChartResponse);
        }

    }
}
