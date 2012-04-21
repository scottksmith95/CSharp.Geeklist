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
	/// Implementation of <see cref="IFollowingOperations"/>, providing binding to Geeklists' following-oriented REST resources.
	/// </summary>
	/// <author>Scott Smith</author>
	class FollowingTemplate : AbstractGeeklistOperations, IFollowingOperations
	{
		private readonly RestTemplate _restTemplate;

		public FollowingTemplate(RestTemplate restTemplate, bool isAuthorized)
			: base(isAuthorized)
		{
			_restTemplate = restTemplate;
		}

		#region IFollowingOperations Members

		public FollowingResponse GetUserFollowing()
		{
			return GetUserFollowing(1, 10);
		}

		public FollowingResponse GetUserFollowing(int page, int count)
		{
			EnsureIsAuthorized();
			var parameters = BuildPagingParametersWithCount(page, count);
			return _restTemplate.GetForObject<FollowingResponse>(BuildUrl("user/following", parameters));
		}

		public FollowingResponse GetUserFollowing(string screenName)
		{
			return GetUserFollowing(screenName, 1, 10);
		}

		public FollowingResponse GetUserFollowing(string screenName, int page, int count)
		{
			var parameters = BuildPagingParametersWithCount(page, count);
			return _restTemplate.GetForObject<FollowingResponse>(BuildUrl("users/" + screenName + "/following", parameters));
		}

		public Task<FollowingResponse> GetUserFollowingAsync()
		{
			return GetUserFollowingAsync(1, 10);
		}

		public Task<FollowingResponse> GetUserFollowingAsync(int page, int count)
		{
			EnsureIsAuthorized();
			var parameters = BuildPagingParametersWithCount(page, count);
			return _restTemplate.GetForObjectAsync<FollowingResponse>(BuildUrl("user/following", parameters));
		}

		public Task<FollowingResponse> GetUserFollowingAsync(string screenName)
		{
			return GetUserFollowingAsync(screenName, 1, 10);
		}

		public Task<FollowingResponse> GetUserFollowingAsync(string screenName, int page, int count)
		{
			var parameters = BuildPagingParametersWithCount(page, count);
			return _restTemplate.GetForObjectAsync<FollowingResponse>(BuildUrl("users/" + screenName + "/following", parameters));
		}

		#endregion

		#region Private Methods



		#endregion
	}
}