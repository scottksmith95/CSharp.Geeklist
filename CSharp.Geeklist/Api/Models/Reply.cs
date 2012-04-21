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
using Newtonsoft.Json;

namespace CSharp.Geeklist.Api.Models
{
	/// <summary>
	/// Represents a Geeklist short code.
	/// </summary>
	/// <author>Scott Smith</author>
	[Serializable]
	public class Reply
	{
		[JsonProperty("in_reply_to")]
		public InReplyTo InReplyTo { get; set; }

		[JsonProperty("thread")]
		public InReplyTo Thread { get; set; }
	}

	public class InReplyTo
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("status")]
		public string Status { get; set; }

		[JsonProperty("permalink")]
		public string Permalink { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("is_active")]
		public bool IsActive { get; set; }
	}
}
