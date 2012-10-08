#region License

/*
 * Copyright 2002-2012 the original author or authors.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#endregion

using System;
using Newtonsoft.Json;

namespace CSharp.Geeklist.Api.Models
{
	/// <summary>
	/// Represents a Geeklist stats.
	/// </summary>
	/// <author>Scott Smith</author>
	[Serializable]
	public class Stats
	{
        [JsonProperty("number_of_cards")]
        public int NumberOfCards { get; set; }

        [JsonProperty("number_of_contributions")]
        public int NumberOfContributions { get; set; }

        [JsonProperty("number_of_creds")]
        public int NumberOfCreds { get; set; }

        [JsonProperty("number_of_highfives")]
        public int NumberOfHighFives { get; set; }

        [JsonProperty("number_of_mentions")]
        public int NumberOfMentions { get; set; }

        [JsonProperty("highfives")]
        public int HighFives { get; set; }

        [JsonProperty("views")]
        public int Views { get; set; }

        [JsonProperty("relinks")]
        public int Relinks { get; set; }

        [JsonProperty("clicks")]
        public int Clicks { get; set; }
	}
}
