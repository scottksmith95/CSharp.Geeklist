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
	/// Implementation of <see cref="IContributionOperations"/>, providing binding to Geeklists' contribution-oriented REST resources.
	/// </summary>
	/// <author>Scott Smith</author>
	class ContributionTemplate : AbstractGeeklistOperations, IContributionOperations
	{
		private readonly RestTemplate _restTemplate;

		public ContributionTemplate(RestTemplate restTemplate, bool isAuthorized)
			: base(isAuthorized)
		{
			_restTemplate = restTemplate;
		}

		#region IContributionOperations Members

		public CardsResponse GetUserContributions()
		{
			return GetUserContributions(1, 10);
		}

		public CardsResponse GetUserContributions(int page, int count)
		{
			EnsureIsAuthorized();
            var parameters = BuildPagingParametersWithCount(page, count);
			return _restTemplate.GetForObject<CardsResponse>(BuildUrl("user/contribs", parameters));
		}

		public CardsResponse GetUserContributions(string screenName)
		{
			return GetUserContributions(screenName, 1, 10);
		}

		public CardsResponse GetUserContributions(string screenName, int page, int count)
		{
			var parameters = BuildPagingParametersWithCount(page, count);
			return _restTemplate.GetForObject<CardsResponse>(BuildUrl("users/" + screenName + "/contribs", parameters));
		}

		public Task<CardsResponse> GetUserContributionsAsync()
		{
			return GetUserContributionsAsync(1, 10);
		}

		public Task<CardsResponse> GetUserContributionsAsync(int page, int count)
		{
			EnsureIsAuthorized();
			var parameters = BuildPagingParametersWithCount(page, count);
			return _restTemplate.GetForObjectAsync<CardsResponse>(BuildUrl("user/contribs", parameters));
		}

		public Task<CardsResponse> GetUserContributionsAsync(string screenName)
		{
			return GetUserContributionsAsync(screenName, 1, 10);
		}

		public Task<CardsResponse> GetUserContributionsAsync(string screenName, int page, int count)
		{
			var parameters = BuildPagingParametersWithCount(page, count);
			return _restTemplate.GetForObjectAsync<CardsResponse>(BuildUrl("users/" + screenName + "/contribs", parameters));
		}

		#endregion

		#region Private Methods



		#endregion
	}
}