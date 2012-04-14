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
	/// JSON deserializer for list of activity. 
	/// </summary>
	/// <author>Scott Smith</author>
	class ActivityListDeserializer : IJsonDeserializer
	{
		public object Deserialize(JsonValue value, JsonMapper mapper)
		{
			value = value.GetValue("data");

			IList<Activity> activities = new List<Activity>();
			foreach (var itemValue in value.GetValues())
			{
				activities.Add(mapper.Deserialize<Activity>(itemValue));
			}
			return activities;
		}
	}

	/// <summary>
	/// JSON deserializer for Geeklist activity.
	/// </summary>
	/// <author>Scott Smith</author>
	class ActivityDeserializer : IJsonDeserializer
	{
		public object Deserialize(JsonValue value, JsonMapper mapper)
		{
			return new Activity
			{
				User = mapper.Deserialize<ShallowUser>(value.GetValue("user")),
				Gfk = mapper.Deserialize<Gfk>(value.GetValue("gfk")),
				Created = value.GetValue<DateTime>("created_at"),
				Updated = value.GetValue<DateTime>("updated_at"),
				Type = value.GetValue<string>("type"),
				Id = value.GetValue<string>("id"),
			};
		}
	}

	/// <summary>
	/// JSON deserializer for Geeklist gfk.
	/// </summary>
	/// <author>Scott Smith</author>
	class GfkDeserializer : IJsonDeserializer
	{
		public object Deserialize(JsonValue value, JsonMapper mapper)
		{
			return new Gfk
			{
				Mentions = value.GetValue<List<string>>("mentions"),
				Hashtags = value.GetValue<List<string>>("hashtags"),
				Details = value.GetValue<List<string>>("details"),
				Avatar = mapper.Deserialize<Avatar>(value.GetValue("avatar")),
				Id = value.GetValue<string>("id"),
				ScreenName = value.GetValue<string>("screen_name"),
			};
		}
	}
}