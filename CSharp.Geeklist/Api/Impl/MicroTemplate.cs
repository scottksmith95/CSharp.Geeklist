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

		public MicrosResponse GetUserMicros()
		{
			return GetUserMicros(1, 10);
		}

		public MicrosResponse GetUserMicros(int page, int count)
		{
			EnsureIsAuthorized();
			var parameters = BuildPagingParametersWithCount(page, count);
			return _restTemplate.GetForObject<MicrosResponse>(BuildUrl("user/micros", parameters));
		}

		public MicrosResponse GetUserMicros(string screenName)
		{
			return GetUserMicros(screenName, 1, 10);
		}

		public MicrosResponse GetUserMicros(string screenName, int page, int count)
		{
			var parameters = BuildPagingParametersWithCount(page, count);
			return _restTemplate.GetForObject<MicrosResponse>(BuildUrl("users/" + screenName + "/micros", parameters));
		}

		public MicroResponse GetMicro(string microId)
		{
			return _restTemplate.GetForObject<MicroResponse>("micros/" + microId);
		}

		public MicroResponse CreateMicro(string status)
		{
			EnsureIsAuthorized();
			var request = new NameValueCollection {{"status", status}};
			return _restTemplate.PostForObject<MicroResponse>("micros", request);
		}

		public MicroResponse CreateMicro(string status, string type, string itemId)
		{
			EnsureIsAuthorized();
			var request = new NameValueCollection { { "status", status }, { "type", type }, { "in_reply_to", itemId } };
			return _restTemplate.PostForObject<MicroResponse>("micros", request);
		}

		public Task<MicrosResponse> GetUserMicrosAsync()
		{
			return GetUserMicrosAsync(1, 10);
		}

		public Task<MicrosResponse> GetUserMicrosAsync(int page, int count)
		{
			EnsureIsAuthorized();
			var parameters = BuildPagingParametersWithCount(page, count);
			return _restTemplate.GetForObjectAsync<MicrosResponse>(BuildUrl("user/micros", parameters));
		}

		public Task<MicrosResponse> GetUserMicrosAsync(string screenName)
		{
			return GetUserMicrosAsync(screenName, 1, 10);
		}

		public Task<MicrosResponse> GetUserMicrosAsync(string screenName, int page, int count)
		{
			var parameters = BuildPagingParametersWithCount(page, count);
			return _restTemplate.GetForObjectAsync<MicrosResponse>(BuildUrl("users/" + screenName + "/micros", parameters));
		}

		public Task<MicroResponse> GetMicroAsync(string microId)
		{
			return _restTemplate.GetForObjectAsync<MicroResponse>("micros/" + microId);
		}

		public Task<MicroResponse> CreateMicroAsync(string status)
		{
			EnsureIsAuthorized();
			var request = new NameValueCollection {{"status", status}};
			return _restTemplate.PostForObjectAsync<MicroResponse>("micros", request);
		}

		public Task<MicroResponse> CreateMicroAsync(string status, string type, string itemId)
		{
			EnsureIsAuthorized();
			var request = new NameValueCollection { { "status", status }, { "type", type }, { "in_reply_to", itemId } };
			return _restTemplate.PostForObjectAsync<MicroResponse>("micros", request);
		}

		#endregion

		#region Private Methods



		#endregion
	}
}