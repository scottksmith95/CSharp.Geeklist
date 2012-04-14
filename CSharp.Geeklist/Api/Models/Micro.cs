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
	/// Represents a Geeklist micro's information.
	/// </summary>
	/// <author>Scott Smith</author>
	[Serializable]
	public class Micro
	{
		/// <summary>
		/// Gets or sets the micro's created date. ("created_at")
		/// </summary>
		public DateTime Created { get; set; }

		/// <summary>
		/// Gets or sets the micro's permanent link. ("permalink")
		/// </summary>
		public string Permalink { get; set; }

		/// <summary>
		/// Gets or sets the micro's slug. ("slug")
		/// </summary>
		public string Slug { get; set; }

		/// <summary>
		/// Gets or sets the micro's status. ("slug")
		/// </summary>
		public string Status { get; set; }

		/// <summary>
		/// Gets or sets the micro's last updated date. ("updated_at")
		/// </summary>
		public DateTime Updated { get; set; }

		/// <summary>
		/// Gets or sets the micro's mentions. ("mentions")
		/// </summary>
		public List<string> Mentions { get; set; }

		/// <summary>
		/// Gets or sets the micro's reply. ("reply")
		/// </summary>
		public Reply Reply { get; set; }

		/// <summary>
		/// Gets or sets the micro's short code. ("shrt_code")
		/// </summary>
		public ShortCode ShortCode { get; set; }

		/// <summary>
		/// Gets or sets the micro's shallow user. ("user")
		/// </summary>
		public ShallowUser User { get; set; }

		/// <summary>
		/// Gets or sets the micro's id. ("id")
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// Gets or sets the micro's high fived state. ("has_highfived")
		/// </summary>
		public bool HasHighFived { get; set; }

		/// <summary>
		/// Gets or sets the micro's is author state. ("is_author")
		/// </summary>
		public bool IsAuthor { get; set; }
	}
}
