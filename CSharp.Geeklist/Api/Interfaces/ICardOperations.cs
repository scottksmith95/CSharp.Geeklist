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
using System.IO;
using System.Collections.Generic;
using Spring.Rest.Client;
using Spring.Http;
using System.Threading.Tasks;

namespace Spring.Social.Geeklist.Api
{
	/// <summary>
	/// Interface defining the operations for searching Geeklist and retrieving card data.
	/// </summary>
	/// <author>Scott Smith</author>
	public interface ICardOperations
	{
		/// <summary>
		/// Retrieves the first 10 cards of the authenticating user.
		/// </summary>
		/// <returns>A <see cref="CardContainer"/> with cards of the authenticating user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		/// <exception cref="GeeklistApiException">If OAuth credentials was not provided.</exception>
		CardContainer GetUserCards();

		/// <summary>
		/// Retrieves cards posted by the authenticating user.
		/// </summary>
		/// <param name="page">The page to return.</param>
		/// <param name="count">
		/// The number of <see cref="Card"/>s per page. Should be less than or equal to 50. 
		/// (Will return at most 50 entries, even if count is greater than 50)
		/// </param>
		/// <returns>A <see cref="CardContainer"/> with cards of the authenticating user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		/// <exception cref="GeeklistApiException">If OAuth credentials was not provided.</exception>
		CardContainer GetUserCards(int page, int count);

		/// <summary>
		/// Retrieves the first 10 cards of the given user.
		/// </summary>
		/// <param name="screenName">The screen name of the user whose cards are being requested.</param>
		/// <returns>A <see cref="CardContainer"/> with cards of the specified user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		CardContainer GetUserCards(string screenName);

		/// <summary>
		/// Retrieves cards posted by the given user.
		/// </summary>
		/// <param name="screenName">The screen name of the user whose cards are being requested.</param>
		/// <param name="page">The page to return.</param>
		/// <param name="count">
		/// The number of <see cref="Card"/>s per page. Should be less than or equal to 50. 
		/// (Will return at most 50 entries, even if count is greater than 50)
		/// </param>
		/// <returns>A <see cref="CardContainer"/> with cards of the specified user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		CardContainer GetUserCards(string screenName, int page, int count);

		/// <summary>
		/// Retrieves the card with the given card id.
		/// </summary>
		/// <param name="cardId">The id of the card whose data is being requested.</param>
		/// <returns>A <see cref="Card"/> with the specified id.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		Card GetCard(string cardId);

		/// <summary>
		/// Creates a new card
		/// </summary>
		/// <param name="headline">The headline for the new card.</param>
		/// <returns>The created <see cref="Card"/>.</returns>
		/// <exception cref="GeekListApiException">If there is an error while communicating with Geeklist.</exception>
		/// <exception cref="GeekListApiException">If OAuth credentials was not provided.</exception>
		Card CreateCard(string headline);

		/// <summary>
		/// Asynchronously retrieves the first 10 cards of the authenticating user.
		/// </summary>
		/// <returns>A <see cref="CardContainer"/> with cards of the authenticating user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		/// <exception cref="GeeklistApiException">If OAuth credentials was not provided.</exception>
		Task<CardContainer> GetUserCardsAsync();

		/// <summary>
		/// Asynchronously retrieves cards posted by the authenticating user.
		/// </summary>
		/// <param name="page">The page to return.</param>
		/// <param name="count">
		/// The number of <see cref="Card"/>s per page. Should be less than or equal to 50. 
		/// (Will return at most 50 entries, even if count is greater than 50)
		/// </param>
		/// <returns>A <see cref="CardContainer"/> with cards of the authenticating user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		/// <exception cref="GeeklistApiException">If OAuth credentials was not provided.</exception>
		Task<CardContainer> GetUserCardsAsync(int page, int count);

		/// <summary>
		/// Asynchronously retrieves the first 10 cards of the given user.
		/// </summary>
		/// <param name="screenName">The screen name of the user whose cards are being requested.</param>
		/// <returns>A <see cref="CardContainer"/> with cards of the specified user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		Task<CardContainer> GetUserCardsAsync(string screenName);

		/// <summary>
		/// Asynchronously retrieves cards posted by the given user.
		/// </summary>
		/// <param name="screenName">The screen name of the user whose cards are being requested.</param>
		/// <param name="page">The page to return.</param>
		/// <param name="count">
		/// The number of <see cref="Card"/>s per page. Should be less than or equal to 50. 
		/// (Will return at most 50 entries, even if count is greater than 50)
		/// </param>
		/// <returns>A <see cref="CardContainer"/> with cards of the specified user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		Task<CardContainer> GetUserCardsAsync(string screenName, int page, int count);

		/// <summary>
		/// Asynchronously retrieves the card with the given card id.
		/// </summary>
		/// <param name="cardId">The id of the card whose data is being requested.</param>
		/// <returns>A <see cref="Card"/> with the specified id.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		Task<Card> GetCardAsync(string cardId);

		/// <summary>
		/// Asynchronously creates a new card
		/// </summary>
		/// <param name="headline">The headline for the new card.</param>
		/// <returns>The created <see cref="Card"/>.</returns>
		/// <exception cref="GeekListApiException">If there is an error while communicating with Geeklist.</exception>
		/// <exception cref="GeekListApiException">If OAuth credentials was not provided.</exception>
		Task<Card> CreateCardAsync(string headline);
	}
}
