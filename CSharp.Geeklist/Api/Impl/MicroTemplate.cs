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

using System.Collections.Specialized;
using CSharp.Geeklist.Api.Interfaces;
using CSharp.Geeklist.Api.Models;
using Spring.Rest.Client;
using System.Threading.Tasks;

namespace CSharp.Geeklist.Api.Impl
{
	/// <summary>
	/// Implementation of <see cref="IMicroOperations"/>, providing binding to Geeklists' micro-oriented REST resources.
	/// </summary>
	/// <author>Scott Smith</author>
	class MicroTemplate : AbstractGeeklistOperations, IMicroOperations
	{
		private readonly RestTemplate _restTemplate;

		public MicroTemplate(RestTemplate restTemplate, bool isAuthorized)
			: base(isAuthorized)
		{
			_restTemplate = restTemplate;
		}

		#region IMicroOperations Members

		public MicroContainer GetUserMicros()
		{
			return GetUserMicros(1, 10);
		}

		public MicroContainer GetUserMicros(int page, int count)
		{
			EnsureIsAuthorized();
			NameValueCollection parameters = BuildPagingParametersWithCount(page, count);
			return _restTemplate.GetForObject<MicroContainer>(BuildUrl("user/micros", parameters));
		}

		public MicroContainer GetUserMicros(string screenName)
		{
			return GetUserMicros(screenName, 1, 10);
		}

		public MicroContainer GetUserMicros(string screenName, int page, int count)
		{
			NameValueCollection parameters = BuildPagingParametersWithCount(page, count);
			return _restTemplate.GetForObject<MicroContainer>(BuildUrl("users/" + screenName + "/micros", parameters));
		}

		public Micro GetMicro(string microId)
		{
			return _restTemplate.GetForObject<Micro>("micros/" + microId);
		}

		public Micro CreateMicro(string status)
		{
			EnsureIsAuthorized();
			var request = new NameValueCollection {{"status", status}};
			return _restTemplate.PostForObject<Micro>("micros", request);
		}

		public Micro CreateMicro(string status, string type, string inReplyToId)
		{
			EnsureIsAuthorized();
			var request = new NameValueCollection {{"status", status}, {"type", type}, {"in_reply_to", inReplyToId}};
			return _restTemplate.PostForObject<Micro>("micros", request);
		}

		public Task<MicroContainer> GetUserMicrosAsync()
		{
			return GetUserMicrosAsync(1, 10);
		}

		public Task<MicroContainer> GetUserMicrosAsync(int page, int count)
		{
			EnsureIsAuthorized();
			NameValueCollection parameters = BuildPagingParametersWithCount(page, count);
			return _restTemplate.GetForObjectAsync<MicroContainer>(BuildUrl("user/micros", parameters));
		}

		public Task<MicroContainer> GetUserMicrosAsync(string screenName)
		{
			return GetUserMicrosAsync(screenName, 1, 10);
		}

		public Task<MicroContainer> GetUserMicrosAsync(string screenName, int page, int count)
		{
			NameValueCollection parameters = BuildPagingParametersWithCount(page, count);
			return _restTemplate.GetForObjectAsync<MicroContainer>(BuildUrl("users/" + screenName + "/micros", parameters));
		}

		public Task<Micro> GetMicroAsync(string microId)
		{
			return _restTemplate.GetForObjectAsync<Micro>("micros/" + microId);
		}

		public Task<Micro> CreateMicroAsync(string status)
		{
			EnsureIsAuthorized();
			var request = new NameValueCollection {{"status", status}};
			return _restTemplate.PostForObjectAsync<Micro>("micros", request);
		}

		public Task<Micro> CreateMicroAsync(string status, string type, string inReplyToId)
		{
			EnsureIsAuthorized();
			var request = new NameValueCollection {{"status", status}, {"type", type}, {"in_reply_to", inReplyToId}};
			return _restTemplate.PostForObjectAsync<Micro>("micros", request);
		}

		#endregion

		#region Private Methods



		#endregion
	}
}