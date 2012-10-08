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

using CSharp.Geeklist.Api.Models;
using Spring.Json;
using Newtonsoft.Json;

namespace CSharp.Geeklist.Api.Impl.Json
{
	/// <summary>
	/// JSON deserializer for a link. 
	/// </summary>
	/// <author>Scott Smith</author>
	class LinkDeserializer : IJsonDeserializer
	{
		public object Deserialize(JsonValue value, JsonMapper mapper)
		{
			var deserializedObject = JsonConvert.DeserializeObject<LinkResponse>(value.ToString());
			deserializedObject.RawJson = value.ToString();
			return deserializedObject;
		}
	}

	/// <summary>
    /// JSON deserializer for links. 
	/// </summary>
	/// <author>Scott Smith</author>
	class LinksDeserializer : IJsonDeserializer
	{
		public object Deserialize(JsonValue value, JsonMapper mapper)
		{
			var deserializedObject = JsonConvert.DeserializeObject<LinksResponse>(value.ToString());
			deserializedObject.RawJson = value.ToString();
			return deserializedObject;
		}
	}
}