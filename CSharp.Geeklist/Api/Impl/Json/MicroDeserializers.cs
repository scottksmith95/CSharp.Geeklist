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
using System.Globalization;
using Spring.Json;

namespace Spring.Social.Geeklist.Api.Impl.Json
{
	/// <summary>
	/// JSON deserializer for data for micros. 
	/// </summary>
	/// <author>Scott Smith</author>
	class MicroContainerDeserializer : IJsonDeserializer
	{
		public object Deserialize(JsonValue value, JsonMapper mapper)
		{
			value = value.GetValue("data");

			return new MicroContainer
			{
				TotalMicros = value.GetValue<long>("total_micros"),
				Micros = mapper.Deserialize<List<Micro>>(value.GetValue("micros"))
			};
		}
	}

	/// <summary>
	/// JSON deserializer for list of micros. 
	/// </summary>
	/// <author>Scott Smith</author>
	class MicroListDeserializer : IJsonDeserializer
	{
		public object Deserialize(JsonValue value, JsonMapper mapper)
		{
			IList<Micro> micros = new List<Micro>();
			foreach (JsonValue itemValue in value.GetValues())
			{
				micros.Add(mapper.Deserialize<Micro>(itemValue));
			}
			return micros;
		}
	}

	/// <summary>
	/// JSON deserializer for Geeklist micro.
	/// </summary>
	/// <author>Scott Smith</author>
	class MicroDeserializer : IJsonDeserializer
	{
		public object Deserialize(JsonValue value, JsonMapper mapper)
		{
			return new Micro()
			{
				Created = value.GetValue<DateTime>("created_at"),
				Permalink = value.GetValue<string>("permalink"),
				Slug = value.GetValue<string>("slug"),
				Status = value.GetValue<string>("status"),
				Updated = value.GetValue<DateTime>("updated_at"),
				Mentions = value.GetValue<List<string>>("mentions"),
				Reply = mapper.Deserialize<Reply>(value.GetValue("reply")),
				ShortCode = mapper.Deserialize<ShortCode>(value.GetValue("short_code")),
				User = mapper.Deserialize<ShallowUser>(value.GetValue("user")),
				Id = value.GetValue<string>("id"),
				HasHighFived = value.GetValue<bool>("has_highfived"),
				IsAuthor = value.GetValue<bool>("is_author")
			};
		}
	}

	/// <summary>
	/// JSON deserializer for Geeklist micro stats.
	/// </summary>
	/// <author>Scott Smith</author>
	class ReplyDeserializer : IJsonDeserializer
	{
		public object Deserialize(JsonValue value, JsonMapper mapper)
		{
			return new Reply()
			{
				Thread = mapper.Deserialize<Thread>(value.GetValue("thread")),
				InReplyTo = mapper.Deserialize<InReplyTo>(value.GetValue("in_reply_to"))
			};
		}
	}

	/// <summary>
	/// JSON deserializer for Geeklist micro stats.
	/// </summary>
	/// <author>Scott Smith</author>
	class ThreadDeserializer : IJsonDeserializer
	{
		public object Deserialize(JsonValue value, JsonMapper mapper)
		{
			return new Thread()
			{
				Id = value.GetValue<string>("id"),
				Status = value.GetValue<string>("status"),
				Permalink = value.GetValue<string>("permalink"),
				Type = value.GetValue<string>("type"),
			};
		}
	}

	/// <summary>
	/// JSON deserializer for Geeklist micro stats.
	/// </summary>
	/// <author>Scott Smith</author>
	class InReplyToDeserializer : IJsonDeserializer
	{
		public object Deserialize(JsonValue value, JsonMapper mapper)
		{
			return new InReplyTo()
			{
				Id = value.GetValue<string>("id"),
				Status = value.GetValue<string>("status"),
				Permalink = value.GetValue<string>("permalink"),
				Type = value.GetValue<string>("type"),
			};
		}
	}
}