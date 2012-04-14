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
	/// Represents a Geeklist user's stats information.
	/// </summary>
	/// <author>Scott Smith</author>
	[Serializable]
	public class UserStats
	{
		/// <summary>
		/// Gets or sets the stat's contribution count. ("number_of_contributions")
		/// </summary>
		public long Contributions { get; set; }

		/// <summary>
		/// Gets or sets the stat's high five count. ("number_of_highfives")
		/// </summary>
		public long HighFives { get; set; }

		/// <summary>
		/// Gets or sets the stat's mention count. ("number_of_mentions")
		/// </summary>
		public long Mentions { get; set; }

		/// <summary>
		/// Gets or sets the stat's card count. ("number_of_cards")
		/// </summary>
		public long Cards { get; set; }

		/// <summary>
		/// Gets or sets the stat's ping count. ("number_of_pings")
		/// </summary>
		public long Pings { get; set; }
	}
}
