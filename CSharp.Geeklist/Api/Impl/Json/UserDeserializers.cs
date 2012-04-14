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
using CSharp.Geeklist.Api.Models;
using Spring.Json;

namespace CSharp.Geeklist.Api.Impl.Json
{
    /// <summary>
    /// JSON deserializer for Geeklist user.
    /// </summary>
    /// <author>Scott Smith</author>
    class UserDeserializer : IJsonDeserializer
    {
        public object Deserialize(JsonValue value, JsonMapper mapper)
        {
			value = value.GetValue("data");

            return new User
            {
                Id = value.GetValue<string>("id"),
                Name = value.GetValue<string>("name"),
				ScreenName = value.GetValue<string>("screen_name"),
				Avatar = mapper.Deserialize<Avatar>(value.GetValue("avatar")),
				BlogLink = value.GetValue<string>("blog_link"),
				Company = mapper.Deserialize<Company>(value.GetValue("company")),
				Location = value.GetValue<string>("location"),
				Bio = value.GetValue<string>("bio"),
				SocialLinks = value.GetValue<List<string>>("social_links"),
				Criteria = mapper.Deserialize<Criteria>(value.GetValue("criteria")),
				Stats = mapper.Deserialize<UserStats>(value.GetValue("stats")),
				Beta = value.GetValue<bool>("is_beta"),
				Created = value.GetValue<DateTime>("created_at"),
				Updated = value.GetValue<DateTime>("updated_at"),
				Active = value.GetValue<DateTime>("active_at"),
				Trending = value.GetValue<DateTime>("trending_at"),
				TrendingHistory = value.GetValue<List<string>>("trending_hist"),
            };
        }
    }

	/// <summary>
    /// JSON deserializer for Geeklist user avatar.
    /// </summary>
    /// <author>Scott Smith</author>
	class AvatarDeserializer : IJsonDeserializer
	{
		public object Deserialize(JsonValue value, JsonMapper mapper)
		{
			return new Avatar
			{
				SmallLink = value.GetValue<string>("small"),
				LargeLink = value.GetValue<string>("large"),
			};
		}
	}

	/// <summary>
	/// JSON deserializer for Geeklist user company.
	/// </summary>
	/// <author>Scott Smith</author>
	class CompanyDeserializer : IJsonDeserializer
	{
		public object Deserialize(JsonValue value, JsonMapper mapper)
		{
			return new Company
			{
				Title = value.GetValue<string>("title"),
				Name = value.GetValue<string>("name"),
			};
		}
	}

	/// <summary>
	/// JSON deserializer for Geeklist user social.
	/// </summary>
	/// <author>Scott Smith</author>
	class SocialDeserializer : IJsonDeserializer
	{
		public object Deserialize(JsonValue value, JsonMapper mapper)
		{
			return new Social
			{
				TwitterScreenName = value.GetValue<string>("twitter_screen_name"),
				TwitterFriends = value.GetValue<long>("twitter_friends_count"),
				TwitterFollowers = value.GetValue<long>("twitter_followers_count"),
			};
		}
	}

	/// <summary>
	/// JSON deserializer for Geeklist user criteria.
	/// </summary>
	/// <author>Scott Smith</author>
	class CriteriaDeserializer : IJsonDeserializer
	{
		public object Deserialize(JsonValue value, JsonMapper mapper)
		{
			return new Criteria
			{
				LookingFor = value.GetValue<List<string>>("looking_for"),
				AvailabeFor = value.GetValue<List<string>>("available_for"),
			};
		}
	}

	/// <summary>
	/// JSON deserializer for Geeklist user stats.
	/// </summary>
	/// <author>Scott Smith</author>
	class UserStatsDeserializer : IJsonDeserializer
	{
		public object Deserialize(JsonValue value, JsonMapper mapper)
		{
			return new UserStats
			{
				Contributions = value.GetValue<long>("number_of_contributions"),
				HighFives = value.GetValue<long>("number_of_highfives"),
				Mentions = value.GetValue<long>("number_of_mentions"),
				Cards = value.GetValue<long>("number_of_cards"),
				Pings = value.GetValue<long>("number_of_pings"),
			};
		}
	}
}