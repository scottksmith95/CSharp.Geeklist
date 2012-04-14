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

namespace CSharp.Geeklist.Api.Models
{
	/// <summary>
	/// Represents a Geeklist card's stats.
	/// </summary>
	/// <author>Scott Smith</author>
	[Serializable]
	public class CardStats
	{
		/// <summary>
		/// Gets or sets the stat's contribution count. ("number_of_views")
		/// </summary>
		public long NumberOfViews { get; set; }

		/// <summary>
		/// Gets or sets the stat's mention count. ("views")
		/// </summary>
		public long Views { get; set; }

		/// <summary>
		/// Gets or sets the stat's high five count. ("highfives")
		/// </summary>
		public long HighFives { get; set; }
	}
}
