using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIProjectTest
{
    public class LyricSnipetResponse : IResponse
    {
        public Message message { get; set; }
    }

    public class LyricsMessage
    {
        public Header header { get; set; }
        public Body body { get; set; }
    }

    public class LyricsHeader
    {
        public int status_code { get; set; }
        public float execute_time { get; set; }
    }

    public class LyricsBody
    {
        public Lyrics lyrics { get; set; }
    }

    public class Lyrics
    {
        public int lyrics_id { get; set; }
        public int _explicit { get; set; }
        public string lyrics_body { get; set; }
        public string script_tracking_url { get; set; }
        public string pixel_tracking_url { get; set; }
        public string lyrics_copyright { get; set; }
        public DateTime updated_time { get; set; }
    }
}
