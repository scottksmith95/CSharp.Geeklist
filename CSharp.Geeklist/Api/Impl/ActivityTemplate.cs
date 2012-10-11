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
using CSharp.Geeklist.Api.Enums;
using CSharp.Geeklist.Api.Interfaces;
using CSharp.Geeklist.Api.Models;
using Spring.Rest.Client;
using System.Threading.Tasks;

namespace CSharp.Geeklist.Api.Impl
{
	/// <summary>
	/// Implementation of <see cref="IActivityOperations"/>, providing binding to Geeklists' activity-oriented REST resources.
	/// </summary>
	/// <author>Scott Smith</author>
	class ActivityTemplate : AbstractGeeklistOperations, IActivityOperations
	{
		private readonly RestTemplate _restTemplate;

		public ActivityTemplate(RestTemplate restTemplate, bool isAuthorized)
			: base(isAuthorized)
		{
			_restTemplate = restTemplate;
		}

		#region IActivityOperations Members

		public ActivitiesResponse GetUserActivities()
		{
			return GetUserActivities(1, 10);
		}

		public ActivitiesResponse GetUserActivities(int page, int count)
		{
			EnsureIsAuthorized();
			var parameters = BuildPagingParametersWithCount(page, count);
			return _restTemplate.GetForObject<ActivitiesResponse>(BuildUrl("user/activity", parameters));
		}

		public ActivitiesResponse GetUserActivities(string screenName)
		{
			return GetUserActivities(screenName, 1, 10);
		}

		public ActivitiesResponse GetUserActivities(string screenName, int page, int count)
		{
			var parameters = BuildPagingParametersWithCount(page, count);
			return _restTemplate.GetForObject<ActivitiesResponse>(BuildUrl("users/" + screenName + "/activity", parameters));
		}

		public ActivitiesResponse GetAllActivities(FilterType filter, FeedType feed, string hash, string start)
		{
			return GetAllActivities(1, 10, filter, feed, hash, start);
		}

        public ActivitiesResponse GetAllActivities(int page, int count, FilterType filter, FeedType feed, string hash, string start)
		{
			var parameters = BuildPagingParametersWithCount(page, count);
			if (filter != FilterType.All) parameters.Add("filter", filter.ToString().ToLower());
            if (feed != FeedType.AuthenticatedUser) parameters.Add("feed", feed.ToString().ToLower());
            if (!string.IsNullOrEmpty(hash)) parameters.Add("hash", hash.ToString().ToLower());
            if (!string.IsNullOrEmpty(start)) parameters.Add("start", start.ToString().ToLower());
			return _restTemplate.GetForObject<ActivitiesResponse>(BuildUrl("activity", parameters));
		}

		public Task<ActivitiesResponse> GetUserActivitiesAsync()
		{
			return GetUserActivitiesAsync(1, 10);
		}

		public Task<ActivitiesResponse> GetUserActivitiesAsync(int page, int count)
		{
			EnsureIsAuthorized();
			var parameters = BuildPagingParametersWithCount(page, count);
			return _restTemplate.GetForObjectAsync<ActivitiesResponse>(BuildUrl("user/activity", parameters));
		}

		public Task<ActivitiesResponse> GetUserActivitiesAsync(string screenName)
		{
			return GetUserActivitiesAsync(screenName, 1, 10);
		}

		public Task<ActivitiesResponse> GetUserActivitiesAsync(string screenName, int page, int count)
		{
			var parameters = BuildPagingParametersWithCount(page, count);
			return _restTemplate.GetForObjectAsync<ActivitiesResponse>(BuildUrl("users/" + screenName + "/activity", parameters));
		}

        public Task<ActivitiesResponse> GetAllActivitiesAsync(FilterType filter, FeedType feed, string hash, string start)
		{
			return GetAllActivitiesAsync(1, 10, filter, feed, hash, start);
		}

        public Task<ActivitiesResponse> GetAllActivitiesAsync(int page, int count, FilterType filter, FeedType feed, string hash, string start)
		{
			var parameters = BuildPagingParametersWithCount(page, count);
			if (filter != FilterType.All) parameters.Add("filter", filter.ToString().ToLower());
            if (feed != FeedType.AuthenticatedUser) parameters.Add("feed", feed.ToString().ToLower());
            if (!string.IsNullOrEmpty(hash)) parameters.Add("hash", hash.ToString().ToLower());
            if (!string.IsNullOrEmpty(start)) parameters.Add("start", start.ToString().ToLower());
			return _restTemplate.GetForObjectAsync<ActivitiesResponse>(BuildUrl("activity", parameters));
		}

		#endregion

		#region Private Methods



		#endregion
	}
}