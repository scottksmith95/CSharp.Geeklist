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
	/// Represents a Geeklist card's information.
	/// </summary>
	/// <author>Scott Smith</author>
	[Serializable]
	public class Card
	{
		/// <summary>
		/// Gets or sets the card's author ID. ("author_id")
		/// </summary>
		public string AuthorId { get; set; }

		/// <summary>
		/// Gets or sets the card's created date. ("created_at")
		/// </summary>
		public DateTime Created { get; set; }

		/// <summary>
		/// Gets or sets the card's happened date. ("happened_at")
		/// </summary>
		public DateTime Happened { get; set; }

		/// <summary>
		/// Gets or sets the card's happened type. ("happened_at_type")
		/// </summary>
		public string HappenedType { get; set; }

		/// <summary>
		/// Gets or sets the card's headline. ("headline")
		/// </summary>
		public string Headline { get; set; }

		/// <summary>
		/// Gets or sets the card's is active flag. ("is_active")
		/// </summary>
		public bool IsActive { get; set; }

		/// <summary>
		/// Gets or sets the card's permanent link. ("permalink")
		/// </summary>
		public string Permalink { get; set; }

		/// <summary>
		/// Gets or sets the card's slug. ("slug")
		/// </summary>
		public string Slug { get; set; }

		/// <summary>
		/// Gets or sets the card's tasks. ("tasks")
		/// </summary>
		public List<string> Tasks { get; set; }

		/// <summary>
		/// Gets or sets the card's last updated date. ("updated_at")
		/// </summary>
		public DateTime Updated { get; set; }

		/// <summary>
		/// Gets or sets the card's stats. ("stats")
		/// </summary>
		public CardStats Stats { get; set; }

		/// <summary>
		/// Gets or sets the card's short code. ("short_code")
		/// </summary>
		public ShortCode ShortCode { get; set; }

		///// <summary>
		///// Gets or sets the card's ID. ("trending_hist")
		///// </summary>
		//public List<string> TrendingHistory { get; set; }

		///// <summary>
		///// Gets or sets the card's ID. ("trending_at")
		///// </summary>
		//public DateTime? TrendingAt { get; set; }

		///// <summary>
		///// Gets or sets the card's ID. ("is_trending")
		///// </summary>
		//public bool IsTrending { get; set; }

		///// <summary>
		///// Gets or sets the card's ID. ("skills")
		///// </summary>
		//public List<string> Skills { get; set; }

		/// <summary>
		/// Gets or sets the card's ID. ("id")
		/// </summary>
		public string Id { get; set; }
	}
}
