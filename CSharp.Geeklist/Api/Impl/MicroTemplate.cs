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
using System.Net;
using System.Collections.Generic;
using System.Collections.Specialized;

using Spring.Http;
using Spring.Rest.Client;
using System.Threading.Tasks;

namespace Spring.Social.Geeklist.Api.Impl
{
	/// <summary>
	/// Implementation of <see cref="IMicroOperations"/>, providing binding to Geeklists' micro-oriented REST resources.
	/// </summary>
	/// <author>Scott Smith</author>
	class MicroTemplate : AbstractGeeklistOperations, IMicroOperations
	{
		private RestTemplate restTemplate;

		public MicroTemplate(RestTemplate restTemplate, bool isAuthorized)
			: base(isAuthorized)
		{
			this.restTemplate = restTemplate;
		}

		#region IMicroOperations Members

		public MicroContainer GetUserMicros()
		{
			return this.GetUserMicros(1, 10);
		}

		public MicroContainer GetUserMicros(int page, int count)
		{
			this.EnsureIsAuthorized();
			NameValueCollection parameters = BuildPagingParametersWithCount(page, count);
			return this.restTemplate.GetForObject<MicroContainer>(this.BuildUrl("user/micros", parameters));
		}

		public MicroContainer GetUserMicros(string screenName)
		{
			return this.GetUserMicros(screenName, 1, 10);
		}

		public MicroContainer GetUserMicros(string screenName, int page, int count)
		{
			NameValueCollection parameters = BuildPagingParametersWithCount(page, count);
			return this.restTemplate.GetForObject<MicroContainer>(this.BuildUrl("users/" + screenName + "/micros", parameters));
		}

		public Micro GetMicro(string microId)
		{
			return this.restTemplate.GetForObject<Micro>("micros/" + microId);
		}

		public Micro CreateMicro(string status)
		{
			this.EnsureIsAuthorized();
			NameValueCollection request = new NameValueCollection();
			request.Add("status", status);
			return this.restTemplate.PostForObject<Micro>("micros", request);
		}

		public Micro CreateMicro(string status, string type, string inReplyToId)
		{
			this.EnsureIsAuthorized();
			NameValueCollection request = new NameValueCollection();
			request.Add("status", status);
			request.Add("type", type);
			request.Add("in_reply_to", inReplyToId);
			return this.restTemplate.PostForObject<Micro>("micros", request);
		}

		public Task<MicroContainer> GetUserMicrosAsync()
		{
			return this.GetUserMicrosAsync(1, 10);
		}

		public Task<MicroContainer> GetUserMicrosAsync(int page, int count)
		{
			this.EnsureIsAuthorized();
			NameValueCollection parameters = BuildPagingParametersWithCount(page, count);
			return this.restTemplate.GetForObjectAsync<MicroContainer>(this.BuildUrl("user/micros", parameters));
		}

		public Task<MicroContainer> GetUserMicrosAsync(string screenName)
		{
			return this.GetUserMicrosAsync(screenName, 1, 10);
		}

		public Task<MicroContainer> GetUserMicrosAsync(string screenName, int page, int count)
		{
			NameValueCollection parameters = BuildPagingParametersWithCount(page, count);
			return this.restTemplate.GetForObjectAsync<MicroContainer>(this.BuildUrl("users/" + screenName + "/micros", parameters));
		}

		public Task<Micro> GetMicroAsync(string microId)
		{
			return this.restTemplate.GetForObjectAsync<Micro>("micros/" + microId);
		}

		public Task<Micro> CreateMicroAsync(string status)
		{
			this.EnsureIsAuthorized();
			NameValueCollection request = new NameValueCollection();
			request.Add("status", status);
			return this.restTemplate.PostForObjectAsync<Micro>("micros", request);
		}

		public Task<Micro> CreateMicroAsync(string status, string type, string inReplyToId)
		{
			this.EnsureIsAuthorized();
			NameValueCollection request = new NameValueCollection();
			request.Add("status", status);
			request.Add("type", type);
			request.Add("in_reply_to", inReplyToId);
			return this.restTemplate.PostForObjectAsync<Micro>("micros", request);
		}

		#endregion

		#region Private Methods



		#endregion
	}
}