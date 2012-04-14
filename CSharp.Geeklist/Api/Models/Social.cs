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

namespace Spring.Social.Geeklist.Api
{
	/// <summary>
	/// Represents a Geeklist user's social information.
	/// </summary>
	/// <author>Scott Smith</author>
	[Serializable]
	public class Social
	{
		/// <summary>
		/// Gets or sets the social's twitter screen namne. ("twitter_screen_name")
		/// </summary>
		public string TwitterScreenName { get; set; }

		/// <summary>
		/// Gets or sets the social's twitter friend count. ("twitter_friends_count")
		/// </summary>
		public long TwitterFriends { get; set; }

		/// <summary>
		/// Gets or sets the social's twitter follower count. ("twitter_followers_count")
		/// </summary>
		public long TwitterFollowers { get; set; }
	}
}
