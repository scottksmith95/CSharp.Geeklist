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
	/// Represents a Geeklist social.
	/// </summary>
	/// <author>Scott Smith</author>
	[Serializable]
	public class Social
	{
		[JsonProperty("twitter_followers_count")]
		public int TwitterFollowersCount { get; set; }

		[JsonProperty("twitter_friends_count")]
		public int TwitterFriendsCount { get; set; }

		[JsonProperty("twitter_screen_name")]
		public string TwitterScreenName { get; set; }
	}
}
