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
using Spring.Http;
using Spring.Rest.Client;
using System.Threading.Tasks;

namespace CSharp.Geeklist.Api.Impl
{
	/// <summary>
	/// Implementation of <see cref="IFollowerOperations"/>, providing binding to Geeklists' follower-oriented REST resources.
	/// </summary>
	/// <author>Scott Smith</author>
	class FollowerTemplate : AbstractGeeklistOperations, IFollowerOperations
	{
		private readonly RestTemplate _restTemplate;

		public FollowerTemplate(RestTemplate restTemplate, bool isAuthorized)
			: base(isAuthorized)
		{
			_restTemplate = restTemplate;
		}

		#region IFollowerOperations Members

		public FollowerContainer GetUserFollowers()
		{
			return GetUserFollowers(1, 10);
		}

		public FollowerContainer GetUserFollowers(int page, int count)
		{
			EnsureIsAuthorized();
			NameValueCollection parameters = BuildPagingParametersWithCount(page, count);
			return _restTemplate.GetForObject<FollowerContainer>(BuildUrl("user/followers", parameters));
		}

		public FollowerContainer GetUserFollowers(string screenName)
		{
			return GetUserFollowers(screenName, 1, 10);
		}

		public FollowerContainer GetUserFollowers(string screenName, int page, int count)
		{
			NameValueCollection parameters = BuildPagingParametersWithCount(page, count);
			return _restTemplate.GetForObject<FollowerContainer>(BuildUrl("users/" + screenName + "/followers", parameters));
		}

		public HttpResponseMessage Follow(string userId)
		{
			EnsureIsAuthorized();
			var request = new NameValueCollection {{"user", userId}, {"type", "follow"}};
			return _restTemplate.PostForMessage("follow", request);
		}

		public HttpResponseMessage UnFollow(string userId)
		{
			EnsureIsAuthorized();
			var request = new NameValueCollection {{"user", userId}};
			return _restTemplate.PostForMessage("follow", request);
		}

		public Task<FollowerContainer> GetUserFollowersAsync()
		{
			return GetUserFollowersAsync(1, 10);
		}

		public Task<FollowerContainer> GetUserFollowersAsync(int page, int count)
		{
			EnsureIsAuthorized();
			NameValueCollection parameters = BuildPagingParametersWithCount(page, count);
			return _restTemplate.GetForObjectAsync<FollowerContainer>(BuildUrl("user/followers", parameters));
		}

		public Task<FollowerContainer> GetUserFollowersAsync(string screenName)
		{
			return GetUserFollowersAsync(screenName, 1, 10);
		}

		public Task<FollowerContainer> GetUserFollowersAsync(string screenName, int page, int count)
		{
			NameValueCollection parameters = BuildPagingParametersWithCount(page, count);
			return _restTemplate.GetForObjectAsync<FollowerContainer>(BuildUrl("users/" + screenName + "/followers", parameters));
		}

		public Task<HttpResponseMessage> FollowAsync(string userId)
		{
			EnsureIsAuthorized();
			var request = new NameValueCollection {{"user", userId}, {"type", "follow"}};
			return _restTemplate.PostForMessageAsync("follow", request);
		}

		public Task<HttpResponseMessage> UnFollowAsync(string userId)
		{
			EnsureIsAuthorized();
			var request = new NameValueCollection {{"user", userId}};
			return _restTemplate.PostForMessageAsync("follow", request);
		}

		#endregion

		#region Private Methods



		#endregion
	}
}