using Newtonsoft.Json;
using System;

namespace APIProjectTest
{
    public class DTO<ResponseType> where ResponseType : IResponse, new()
    {
        //
        public ResponseType Response { get; set; }
        public void DeserializeResponse(string TrackSearchResponse)
        {
            Response = JsonConvert.DeserializeObject<ResponseType>(TrackSearchResponse);
        }
    }
}
