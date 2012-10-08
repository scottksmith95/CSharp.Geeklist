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
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CSharp.Geeklist.Api.Models
{
	/// <summary>
	/// Represents a Geeklist link.
	/// </summary>
	/// <author>Scott Smith</author>
	[Serializable]
	public class Link
	{
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("title")]
		public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("permalink")]
        public string Permalink { get; set; }

        [JsonProperty("_id")]
		public string Id { get; set; }

        [JsonProperty("trending_hist")]
        public List<TrendingHistory> TrendingHist { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("is_trending")]
		public bool IsTrending { get; set; }

        [JsonProperty("is_active")]
        public bool IsActive { get; set; }

        [JsonProperty("communities")]
        public List<Community> Communities { get; set; }

        [JsonProperty("ranking")]
        public Ranking Ranking { get; set; }

        [JsonProperty("stats")]
        public Stats Stats { get; set; }

        [JsonProperty("user")]
        public TinyUser User { get; set; }

        [JsonProperty("from_link")]
        public FromLink FromLink { get; set; }

        [JsonProperty("category")]
        public Category Category { get; set; }
	}

    public class Community
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }
    }

    public class Ranking
    {
        [JsonProperty("rating")]
        public double Rating { get; set; }

        [JsonProperty("score")]
        public int Score { get; set; }

        [JsonProperty("votes")]
        public int Votes { get; set; }
    }

    public class TinyUser
    {
        [JsonProperty("id")]
        public string id { get; set; }
    }

    public class FromLink
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("user")]
        public TinyUser User { get; set; }
    }

    public class Category
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
