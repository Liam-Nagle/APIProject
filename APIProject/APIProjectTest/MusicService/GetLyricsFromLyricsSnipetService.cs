﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIProjectTest
{
    class GetLyricsFromLyricsSnipetService
    {
        public CallManager CallManager { get; set; }
        public JObject Json_Response { get; set; }
        public DTO<LyricSnipetResponse> LyricSnipetDTO { get; set; }
        public DTO<TrackResponse> TrackResponseDTO { get; set; }
        public string LyricSnipetResponse { get; set; }

        public GetLyricsFromLyricsSnipetService()
        {
            CallManager = new CallManager();
            LyricSnipetDTO = new DTO<LyricSnipetResponse>();
            TrackResponseDTO = new DTO<TrackResponse>();
        }

        public async Task MakeGetLyricsByLyricSnipetAsync(string lyricSnipet)
        {
            var idResponse = CallManager.GetTrackIDByLyricSnipet(lyricSnipet);
            int trackid;

            TrackResponseDTO.DeserializeResponse(idResponse);

            try
            {
                trackid = TrackResponseDTO.Response.message.body.track_list[0].track.track_id;
            }
            catch (IndexOutOfRangeException e)
            {
                throw new ArgumentException("There were no songs with those lyrics in!");
            }

            LyricSnipetResponse = await CallManager.GetTrackLyricsByTrackIDAsync(trackid);

            Json_Response = JObject.Parse(LyricSnipetResponse);

            LyricSnipetDTO.DeserializeResponse(LyricSnipetResponse);
        }
    }
}
