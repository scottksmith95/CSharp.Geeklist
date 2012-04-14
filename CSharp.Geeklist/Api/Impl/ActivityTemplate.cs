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

using System.Collections.Generic;
using System.Collections.Specialized;
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

		public IList<Activity> GetUserActivities()
		{
			return GetUserActivities(1, 10);
		}

		public IList<Activity> GetUserActivities(int page, int count)
		{
			EnsureIsAuthorized();
			NameValueCollection parameters = BuildPagingParametersWithCount(page, count);
			return _restTemplate.GetForObject<IList<Activity>>(BuildUrl("user/activity", parameters));
		}

		public IList<Activity> GetUserActivities(string screenName)
		{
			return GetUserActivities(screenName, 1, 10);
		}

		public IList<Activity> GetUserActivities(string screenName, int page, int count)
		{
			NameValueCollection parameters = BuildPagingParametersWithCount(page, count);
			return _restTemplate.GetForObject<IList<Activity>>(BuildUrl("users/" + screenName + "/activity", parameters));
		}

		public IList<Activity> GetAllActivities()
		{
			return GetAllActivities(1, 10);
		}

		public IList<Activity> GetAllActivities(int page, int count)
		{
			NameValueCollection parameters = BuildPagingParametersWithCount(page, count);
			return _restTemplate.GetForObject<IList<Activity>>(BuildUrl("activity", parameters));
		}

		public Task<IList<Activity>> GetUserActivitiesAsync()
		{
			return GetUserActivitiesAsync(1, 10);
		}

		public Task<IList<Activity>> GetUserActivitiesAsync(int page, int count)
		{
			EnsureIsAuthorized();
			NameValueCollection parameters = BuildPagingParametersWithCount(page, count);
			return _restTemplate.GetForObjectAsync<IList<Activity>>(BuildUrl("user/activity", parameters));
		}

		public Task<IList<Activity>> GetUserActivitiesAsync(string screenName)
		{
			return GetUserActivitiesAsync(screenName, 1, 10);
		}

		public Task<IList<Activity>> GetUserActivitiesAsync(string screenName, int page, int count)
		{
			NameValueCollection parameters = BuildPagingParametersWithCount(page, count);
			return _restTemplate.GetForObjectAsync<IList<Activity>>(BuildUrl("users/" + screenName + "/activity", parameters));
		}

		public Task<IList<Activity>> GetAllActivitiesAsync()
		{
			return GetAllActivitiesAsync(1, 10);
		}

		public Task<IList<Activity>> GetAllActivitiesAsync(int page, int count)
		{
			NameValueCollection parameters = BuildPagingParametersWithCount(page, count);
			return _restTemplate.GetForObjectAsync<IList<Activity>>(BuildUrl("activity", parameters));
		}

		#endregion

		#region Private Methods



		#endregion
	}
}