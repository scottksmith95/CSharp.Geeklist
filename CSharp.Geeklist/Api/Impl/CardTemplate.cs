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
	/// Implementation of <see cref="ICardOperations"/>, providing binding to Geeklists' card-oriented REST resources.
	/// </summary>
	/// <author>Scott Smith</author>
	class CardTemplate : AbstractGeeklistOperations, ICardOperations
	{
		private RestTemplate restTemplate;

		public CardTemplate(RestTemplate restTemplate, bool isAuthorized)
			: base(isAuthorized)
		{
			this.restTemplate = restTemplate;
		}

		#region ICardOperations Members

		public CardContainer GetUserCards()
		{
			return this.GetUserCards(1, 10);
		}

		public CardContainer GetUserCards(int page, int count)
		{
			this.EnsureIsAuthorized();
            NameValueCollection parameters = BuildPagingParametersWithCount(page, count);
			return this.restTemplate.GetForObject<CardContainer>(this.BuildUrl("user/cards", parameters));
		}

		public CardContainer GetUserCards(string screenName)
		{
			return this.GetUserCards(screenName, 1, 10);
		}

		public CardContainer GetUserCards(string screenName, int page, int count)
		{
			NameValueCollection parameters = BuildPagingParametersWithCount(page, count);
			return this.restTemplate.GetForObject<CardContainer>(this.BuildUrl("users/" + screenName + "/cards", parameters));
		}

		public Card GetCard(string cardId)
		{
			return this.restTemplate.GetForObject<Card>("cards/" + cardId);
		}

		public Card CreateCard(string headline)
		{
			this.EnsureIsAuthorized();
			NameValueCollection request = new NameValueCollection();
			request.Add("headline", headline);
			return this.restTemplate.PostForObject<Card>("cards", request);
		}

		public Task<CardContainer> GetUserCardsAsync()
		{
			return this.GetUserCardsAsync(1, 10);
		}

		public Task<CardContainer> GetUserCardsAsync(int page, int count)
		{
			this.EnsureIsAuthorized();
			NameValueCollection parameters = BuildPagingParametersWithCount(page, count);
			return this.restTemplate.GetForObjectAsync<CardContainer>(this.BuildUrl("user/cards", parameters));
		}

		public Task<CardContainer> GetUserCardsAsync(string screenName)
		{
			return this.GetUserCardsAsync(screenName, 1, 10);
		}

		public Task<CardContainer> GetUserCardsAsync(string screenName, int page, int count)
		{
			NameValueCollection parameters = BuildPagingParametersWithCount(page, count);
			return this.restTemplate.GetForObjectAsync<CardContainer>(this.BuildUrl("users/" + screenName + "/cards", parameters));
		}

		public Task<Card> GetCardAsync(string cardId)
		{
			return this.restTemplate.GetForObjectAsync<Card>("cards/" + cardId);
		}

		public Task<Card> CreateCardAsync(string headline)
		{
			this.EnsureIsAuthorized();
			NameValueCollection request = new NameValueCollection();
			request.Add("headline", headline);
			return this.restTemplate.PostForObjectAsync<Card>("cards", request);
		}

		#endregion

		#region Private Methods



		#endregion
	}
}