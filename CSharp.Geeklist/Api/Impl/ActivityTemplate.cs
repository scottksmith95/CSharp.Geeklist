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
	/// Implementation of <see cref="IActivityOperations"/>, providing binding to Geeklists' activity-oriented REST resources.
	/// </summary>
	/// <author>Scott Smith</author>
	class ActivityTemplate : AbstractGeeklistOperations, IActivityOperations
	{
		private RestTemplate restTemplate;

		public ActivityTemplate(RestTemplate restTemplate, bool isAuthorized)
			: base(isAuthorized)
		{
			this.restTemplate = restTemplate;
		}

		#region IActivityOperations Members

		public IList<Activity> GetUserActivities()
		{
			return this.GetUserActivities(1, 10);
		}

		public IList<Activity> GetUserActivities(int page, int count)
		{
			this.EnsureIsAuthorized();
			NameValueCollection parameters = BuildPagingParametersWithCount(page, count);
			return this.restTemplate.GetForObject<IList<Activity>>(this.BuildUrl("user/activity", parameters));
		}

		public IList<Activity> GetUserActivities(string screenName)
		{
			return this.GetUserActivities(screenName, 1, 10);
		}

		public IList<Activity> GetUserActivities(string screenName, int page, int count)
		{
			NameValueCollection parameters = BuildPagingParametersWithCount(page, count);
			return this.restTemplate.GetForObject<IList<Activity>>(this.BuildUrl("users/" + screenName + "/activity", parameters));
		}

		public IList<Activity> GetAllActivities()
		{
			return this.GetAllActivities(1, 10);
		}

		public IList<Activity> GetAllActivities(int page, int count)
		{
			NameValueCollection parameters = BuildPagingParametersWithCount(page, count);
			return this.restTemplate.GetForObject<IList<Activity>>(this.BuildUrl("activity", parameters));
		}

		public Task<IList<Activity>> GetUserActivitiesAsync()
		{
			return this.GetUserActivitiesAsync(1, 10);
		}

		public Task<IList<Activity>> GetUserActivitiesAsync(int page, int count)
		{
			this.EnsureIsAuthorized();
			NameValueCollection parameters = BuildPagingParametersWithCount(page, count);
			return this.restTemplate.GetForObjectAsync<IList<Activity>>(this.BuildUrl("user/activity", parameters));
		}

		public Task<IList<Activity>> GetUserActivitiesAsync(string screenName)
		{
			return this.GetUserActivitiesAsync(screenName, 1, 10);
		}

		public Task<IList<Activity>> GetUserActivitiesAsync(string screenName, int page, int count)
		{
			NameValueCollection parameters = BuildPagingParametersWithCount(page, count);
			return this.restTemplate.GetForObjectAsync<IList<Activity>>(this.BuildUrl("users/" + screenName + "/activity", parameters));
		}

		public Task<IList<Activity>> GetAllActivitiesAsync()
		{
			return this.GetAllActivitiesAsync(1, 10);
		}

		public Task<IList<Activity>> GetAllActivitiesAsync(int page, int count)
		{
			NameValueCollection parameters = BuildPagingParametersWithCount(page, count);
			return this.restTemplate.GetForObjectAsync<IList<Activity>>(this.BuildUrl("activity", parameters));
		}

		#endregion

		#region Private Methods



		#endregion
	}
}