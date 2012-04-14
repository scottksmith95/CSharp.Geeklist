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

		public CardContainer GetUserCards()
		{
			return GetUserCards(1, 10);
		}

		public CardContainer GetUserCards(int page, int count)
		{
			EnsureIsAuthorized();
            NameValueCollection parameters = BuildPagingParametersWithCount(page, count);
			return _restTemplate.GetForObject<CardContainer>(BuildUrl("user/cards", parameters));
		}

		public CardContainer GetUserCards(string screenName)
		{
			return GetUserCards(screenName, 1, 10);
		}

		public CardContainer GetUserCards(string screenName, int page, int count)
		{
			NameValueCollection parameters = BuildPagingParametersWithCount(page, count);
			return _restTemplate.GetForObject<CardContainer>(BuildUrl("users/" + screenName + "/cards", parameters));
		}

		public Card GetCard(string cardId)
		{
			return _restTemplate.GetForObject<Card>("cards/" + cardId);
		}

		public Card CreateCard(string headline)
		{
			EnsureIsAuthorized();
			var request = new NameValueCollection {{"headline", headline}};
			return _restTemplate.PostForObject<Card>("cards", request);
		}

		public Task<CardContainer> GetUserCardsAsync()
		{
			return GetUserCardsAsync(1, 10);
		}

		public Task<CardContainer> GetUserCardsAsync(int page, int count)
		{
			EnsureIsAuthorized();
			NameValueCollection parameters = BuildPagingParametersWithCount(page, count);
			return _restTemplate.GetForObjectAsync<CardContainer>(BuildUrl("user/cards", parameters));
		}

		public Task<CardContainer> GetUserCardsAsync(string screenName)
		{
			return GetUserCardsAsync(screenName, 1, 10);
		}

		public Task<CardContainer> GetUserCardsAsync(string screenName, int page, int count)
		{
			NameValueCollection parameters = BuildPagingParametersWithCount(page, count);
			return _restTemplate.GetForObjectAsync<CardContainer>(BuildUrl("users/" + screenName + "/cards", parameters));
		}

		public Task<Card> GetCardAsync(string cardId)
		{
			return _restTemplate.GetForObjectAsync<Card>("cards/" + cardId);
		}

		public Task<Card> CreateCardAsync(string headline)
		{
			EnsureIsAuthorized();
			var request = new NameValueCollection {{"headline", headline}};
			return _restTemplate.PostForObjectAsync<Card>("cards", request);
		}

		#endregion

		#region Private Methods



		#endregion
	}
}