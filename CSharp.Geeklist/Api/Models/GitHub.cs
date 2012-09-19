using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace CSharp.Geeklist.Api.Models
{
    public class GitHub
    {
        [JsonProperty("username")]
        public string Username { get; set; }
    }
}
