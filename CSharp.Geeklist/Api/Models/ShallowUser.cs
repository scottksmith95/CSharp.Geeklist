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
	/// Represents a Geeklist user's shallow profile information.
	/// </summary>
	/// <author>Scott Smith</author>
	[Serializable]
	public class ShallowUser 
	{
		/// <summary>
		/// Gets or sets the user's ID. ("id")
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// Gets or sets the user's screen name. ("screen_name")
		/// </summary>
		public string ScreenName { get; set; }

		/// <summary>
		/// Gets or sets the user's avatar. ("avatar")
		/// </summary>
		public Avatar Avatar { get; set; }
	}
}
