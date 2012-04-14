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

namespace CSharp.Geeklist.Api.Models
{
    /// <summary>
    /// Represents a Geeklist user's profile information.
    /// </summary>
	/// <author>Scott Smith</author>
    [Serializable]
    public class User 
    {
        /// <summary>
        /// Gets or sets the user's ID. ("id")
        /// </summary>
	    public string Id { get; set; }

        /// <summary>
        /// Gets or sets the user's full name. ("name")
        /// </summary>
        public string Name { get; set; }

		/// <summary>
		/// Gets or sets the user's screen name. ("screen_name")
		/// </summary>
		public string ScreenName { get; set; }

		/// <summary>
		/// Gets or sets the user's avatar. ("avatar")
		/// </summary>
		public Avatar Avatar { get; set; }

		/// <summary>
		/// Gets or sets the user's blog link. ("blog_link")
		/// </summary>
		public string BlogLink { get; set; }

		/// <summary>
		/// Gets or sets the user's company. ("company")
		/// </summary>
		public Company Company { get; set; }

		/// <summary>
		/// Gets or sets the user's location. ("location")
		/// </summary>
		public string Location { get; set; }

		/// <summary>
		/// Gets or sets the user's bio. ("bio")
		/// </summary>
		public string Bio { get; set; }

		/// <summary>
		/// Gets or sets the user's social links. ("social_links")
		/// </summary>
		public List<string> SocialLinks { get; set; }

		/// <summary>
		/// Gets or sets the user's social. ("social")
		/// </summary>
		public CSharp.Geeklist.Api.Models.Social Social { get; set; }

		/// <summary>
		/// Gets or sets the user's criteria. ("criteria")
		/// </summary>
		public Criteria Criteria { get; set; }

		/// <summary>
		/// Gets or sets the user's stats. ("stats")
		/// </summary>
		public UserStats Stats { get; set; }

		/// <summary>
		/// Gets or sets the user's beta status. ("is_beta")
		/// </summary>
		public bool Beta { get; set; }

		/// <summary>
		/// Gets or sets the user's created date. ("created_at")
		/// </summary>
		public DateTime Created { get; set; }

		/// <summary>
		/// Gets or sets the user's last updated date. ("updated_at")
		/// </summary>
		public DateTime Updated { get; set; }

		/// <summary>
		/// Gets or sets the user's last active date. ("active_at")
		/// </summary>
		public DateTime Active { get; set; }

		/// <summary>
		/// Gets or sets the user's last trending date. ("trending_at")
		/// </summary>
		public DateTime Trending { get; set; }

		/// <summary>
		/// Gets or sets the user's trending history. ("trending_hist")
		/// </summary>
		public List<string> TrendingHistory { get; set; }

		/// <summary>
		/// Gets the URL of the user's profile.
		/// </summary>
		public string ProfileUrl
		{
			get { return "http://geekli.st/" + ScreenName; }
		}
    }
}
