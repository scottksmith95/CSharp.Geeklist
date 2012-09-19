using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace CSharp.Geeklist.Api.Models
{
    public class Images
    {
        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty("low_res")]
        public string LowRes { get; set; }

        [JsonProperty("full_size")]
        public string FullSize { get; set; }

        [JsonProperty("www_url")]
        public string WWWUrl { get; set; }

        [JsonProperty("photo_id")]
        public string PhotoId { get; set; }
    }
}
