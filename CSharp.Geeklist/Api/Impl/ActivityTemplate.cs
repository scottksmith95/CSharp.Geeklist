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

		public ActivitiesResponse GetUserActivities(ActivityType type)
		{
			return GetUserActivities(1, 10, type);
		}

		public ActivitiesResponse GetUserActivities(int page, int count, ActivityType type)
		{
			EnsureIsAuthorized();
			var parameters = BuildPagingParametersWithCount(page, count);
			if (type != ActivityType.All) parameters.Add("type", type.ToString().ToLower());
			return _restTemplate.GetForObject<ActivitiesResponse>(BuildUrl("user/activity", parameters));
		}

		public ActivitiesResponse GetUserActivities(string screenName, ActivityType type)
		{
			return GetUserActivities(screenName, 1, 10, type);
		}

		public ActivitiesResponse GetUserActivities(string screenName, int page, int count, ActivityType type)
		{
			var parameters = BuildPagingParametersWithCount(page, count);
			if (type != ActivityType.All) parameters.Add("type", type.ToString().ToLower());
			return _restTemplate.GetForObject<ActivitiesResponse>(BuildUrl("users/" + screenName + "/activity", parameters));
		}

		public ActivitiesResponse GetAllActivities(ActivityType type)
		{
			return GetAllActivities(1, 10, type);
		}

		public ActivitiesResponse GetAllActivities(int page, int count, ActivityType type)
		{
			var parameters = BuildPagingParametersWithCount(page, count);
			if (type != ActivityType.All) parameters.Add("type", type.ToString().ToLower());
			return _restTemplate.GetForObject<ActivitiesResponse>(BuildUrl("activity", parameters));
		}

		public Task<ActivitiesResponse> GetUserActivitiesAsync(ActivityType type)
		{
			return GetUserActivitiesAsync(1, 10, type);
		}

		public Task<ActivitiesResponse> GetUserActivitiesAsync(int page, int count, ActivityType type)
		{
			EnsureIsAuthorized();
			var parameters = BuildPagingParametersWithCount(page, count);
			if (type != ActivityType.All) parameters.Add("type", type.ToString().ToLower());
			return _restTemplate.GetForObjectAsync<ActivitiesResponse>(BuildUrl("user/activity", parameters));
		}

		public Task<ActivitiesResponse> GetUserActivitiesAsync(string screenName, ActivityType type)
		{
			return GetUserActivitiesAsync(screenName, 1, 10, type);
		}

		public Task<ActivitiesResponse> GetUserActivitiesAsync(string screenName, int page, int count, ActivityType type)
		{
			var parameters = BuildPagingParametersWithCount(page, count);
			if (type != ActivityType.All) parameters.Add("type", type.ToString().ToLower());
			return _restTemplate.GetForObjectAsync<ActivitiesResponse>(BuildUrl("users/" + screenName + "/activity", parameters));
		}

		public Task<ActivitiesResponse> GetAllActivitiesAsync(ActivityType type)
		{
			return GetAllActivitiesAsync(1, 10, type);
		}

		public Task<ActivitiesResponse> GetAllActivitiesAsync(int page, int count, ActivityType type)
		{
			var parameters = BuildPagingParametersWithCount(page, count);
			if (type != ActivityType.All) parameters.Add("type", type.ToString().ToLower());
			return _restTemplate.GetForObjectAsync<ActivitiesResponse>(BuildUrl("activity", parameters));
		}

		#endregion

		#region Private Methods



		#endregion
	}
}