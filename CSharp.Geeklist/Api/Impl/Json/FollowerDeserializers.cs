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

using System.Collections.Generic;
using CSharp.Geeklist.Api.Models;
using Spring.Json;

namespace CSharp.Geeklist.Api.Impl.Json
{
	/// <summary>
	/// JSON deserializer for data for followers. 
	/// </summary>
	/// <author>Scott Smith</author>
	class FollowerContainerDeserializer : IJsonDeserializer
	{
		public object Deserialize(JsonValue value, JsonMapper mapper)
		{
			value = value.GetValue("data");

			return new FollowerContainer
			{
				TotalFollowers = value.GetValue<long>("total_followers"),
				Followers = mapper.Deserialize<List<User>>(value.GetValue("followers"))
			};
		}
	}
}
