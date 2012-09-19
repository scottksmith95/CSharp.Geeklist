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
	/// Implementation of <see cref="ICardOperations"/>, providing binding to Geeklists' card-oriented REST resources.
	/// </summary>
	/// <author>Scott Smith</author>
	class CardTemplate : AbstractGeeklistOperations, ICardOperations
	{
		private readonly RestTemplate _restTemplate;

		public CardTemplate(RestTemplate restTemplate, bool isAuthorized)
			: base(isAuthorized)
		{
			_restTemplate = restTemplate;
		}

		#region ICardOperations Members

		public CardsResponse GetUserCards(bool featured = false)
		{
            return GetUserCards(1, 10, featured);
		}

        public CardsResponse GetUserCards(int page, int count, bool featured = false)
		{
			EnsureIsAuthorized();
            var parameters = BuildPagingParametersWithCount(page, count);
            if (featured)
                parameters.Add(new NameValueCollection { { "featured", featured.ToString() } });
			return _restTemplate.GetForObject<CardsResponse>(BuildUrl("user/cards", parameters));
		}

        public CardsResponse GetUserCards(string screenName, bool featured = false)
		{
            return GetUserCards(screenName, 1, 10, featured);
		}

        public CardsResponse GetUserCards(string screenName, int page, int count, bool featured = false)
		{
			var parameters = BuildPagingParametersWithCount(page, count);
            if (featured)
                parameters.Add(new NameValueCollection { { "featured", featured.ToString() } });
			return _restTemplate.GetForObject<CardsResponse>(BuildUrl("users/" + screenName + "/cards", parameters));
		}

		public CardResponse GetCard(string cardId)
		{
			return _restTemplate.GetForObject<CardResponse>("cards/" + cardId);
		}

		public CardResponse CreateCard(string headline)
		{
			EnsureIsAuthorized();
			var request = new NameValueCollection {{"headline", headline}};
			return _restTemplate.PostForObject<CardResponse>("cards", request);
		}

		public Task<CardsResponse> GetUserCardsAsync(bool featured = false)
		{
            return GetUserCardsAsync(1, 10, featured);
		}

        public Task<CardsResponse> GetUserCardsAsync(int page, int count, bool featured = false)
		{
			EnsureIsAuthorized();
			var parameters = BuildPagingParametersWithCount(page, count);
            if (featured)
                parameters.Add(new NameValueCollection { { "featured", featured.ToString() } });
			return _restTemplate.GetForObjectAsync<CardsResponse>(BuildUrl("user/cards", parameters));
		}

        public Task<CardsResponse> GetUserCardsAsync(string screenName, bool featured = false)
		{
            return GetUserCardsAsync(screenName, 1, 10, featured);
		}

        public Task<CardsResponse> GetUserCardsAsync(string screenName, int page, int count, bool featured = false)
		{
			var parameters = BuildPagingParametersWithCount(page, count);
            if (featured)
                parameters.Add(new NameValueCollection { { "featured", featured.ToString() } });
			return _restTemplate.GetForObjectAsync<CardsResponse>(BuildUrl("users/" + screenName + "/cards", parameters));
		}

		public Task<CardResponse> GetCardAsync(string cardId)
		{
			return _restTemplate.GetForObjectAsync<CardResponse>("cards/" + cardId);
		}

		public Task<CardResponse> CreateCardAsync(string headline)
		{
			EnsureIsAuthorized();
			var request = new NameValueCollection {{"headline", headline}};
			return _restTemplate.PostForObjectAsync<CardResponse>("cards", request);
		}

		#endregion

		#region Private Methods



		#endregion
	}
}