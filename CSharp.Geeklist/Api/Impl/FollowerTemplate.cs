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
	/// Implementation of <see cref="IFollowerOperations"/>, providing binding to Geeklists' follower-oriented REST resources.
	/// </summary>
	/// <author>Scott Smith</author>
	class FollowerTemplate : AbstractGeeklistOperations, IFollowerOperations
	{
		private RestTemplate restTemplate;

		public FollowerTemplate(RestTemplate restTemplate, bool isAuthorized)
			: base(isAuthorized)
		{
			this.restTemplate = restTemplate;
		}

		#region IFollowerOperations Members

		public FollowerContainer GetUserFollowers()
		{
			return this.GetUserFollowers(1, 10);
		}

		public FollowerContainer GetUserFollowers(int page, int count)
		{
			this.EnsureIsAuthorized();
			NameValueCollection parameters = BuildPagingParametersWithCount(page, count);
			return this.restTemplate.GetForObject<FollowerContainer>(this.BuildUrl("user/followers", parameters));
		}

		public FollowerContainer GetUserFollowers(string screenName)
		{
			return this.GetUserFollowers(screenName, 1, 10);
		}

		public FollowerContainer GetUserFollowers(string screenName, int page, int count)
		{
			NameValueCollection parameters = BuildPagingParametersWithCount(page, count);
			return this.restTemplate.GetForObject<FollowerContainer>(this.BuildUrl("users/" + screenName + "/followers", parameters));
		}

		public HttpResponseMessage Follow(string userId)
		{
			this.EnsureIsAuthorized();
			NameValueCollection request = new NameValueCollection();
			request.Add("user", userId);
			request.Add("type", "follow");
			return this.restTemplate.PostForMessage("follow", request);
		}

		public HttpResponseMessage UnFollow(string userId)
		{
			this.EnsureIsAuthorized();
			NameValueCollection request = new NameValueCollection();
			request.Add("user", userId);
			return this.restTemplate.PostForMessage("follow", request);
		}

		public Task<FollowerContainer> GetUserFollowersAsync()
		{
			return this.GetUserFollowersAsync(1, 10);
		}

		public Task<FollowerContainer> GetUserFollowersAsync(int page, int count)
		{
			this.EnsureIsAuthorized();
			NameValueCollection parameters = BuildPagingParametersWithCount(page, count);
			return this.restTemplate.GetForObjectAsync<FollowerContainer>(this.BuildUrl("user/followers", parameters));
		}

		public Task<FollowerContainer> GetUserFollowersAsync(string screenName)
		{
			return this.GetUserFollowersAsync(screenName, 1, 10);
		}

		public Task<FollowerContainer> GetUserFollowersAsync(string screenName, int page, int count)
		{
			NameValueCollection parameters = BuildPagingParametersWithCount(page, count);
			return this.restTemplate.GetForObjectAsync<FollowerContainer>(this.BuildUrl("users/" + screenName + "/followers", parameters));
		}

		public Task<HttpResponseMessage> FollowAsync(string userId)
		{
			this.EnsureIsAuthorized();
			NameValueCollection request = new NameValueCollection();
			request.Add("user", userId);
			request.Add("type", "follow");
			return this.restTemplate.PostForMessageAsync("follow", request);
		}

		public Task<HttpResponseMessage> UnFollowAsync(string userId)
		{
			this.EnsureIsAuthorized();
			NameValueCollection request = new NameValueCollection();
			request.Add("user", userId);
			return this.restTemplate.PostForMessageAsync("follow", request);
		}

		#endregion

		#region Private Methods



		#endregion
	}
}