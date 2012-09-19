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

using System.Threading.Tasks;
using CSharp.Geeklist.Api.Models;

namespace CSharp.Geeklist.Api.Interfaces
{
	/// <summary>
	/// Interface defining the operations for Geeklist card data.
	/// </summary>
	/// <author>Scott Smith</author>
	public interface ICardOperations
	{
		/// <summary>
		/// Retrieves the first 10 cards of the authenticated user.
		/// </summary>
        /// <param name="featured">Returns only featured cards.</param>
		/// <returns>A <see cref="CardsResponse"/> with cards of the authenticated user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		CardsResponse GetUserCards(bool featured = false);

		/// <summary>
		/// Retrieves cards of the authenticated user.
		/// </summary>
		/// <param name="page">The page to return.</param>
		/// <param name="count">
		/// The number of <see cref="CardResponse"/>s per page. Should be less than or equal to 50. 
		/// (Will return at most 50 entries, even if count is greater than 50)
		/// </param>
        /// <param name="featured">Returns only featured cards.</param>
		/// <returns>A <see cref="CardsResponse"/> with cards of the authenticated user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
        CardsResponse GetUserCards(int page, int count, bool featured = false);

		/// <summary>
		/// Retrieves the first 10 cards of the given user.
		/// </summary>
		/// <param name="screenName">The screen name of the user whose cards are being requested.</param>
        /// <param name="featured">Returns only featured cards.</param>
		/// <returns>A <see cref="CardsResponse"/> with cards of the specified user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
        CardsResponse GetUserCards(string screenName, bool featured = false);

		/// <summary>
		/// Retrieves cards of the given user.
		/// </summary>
		/// <param name="screenName">The screen name of the user whose cards are being requested.</param>
		/// <param name="page">The page to return.</param>
		/// <param name="count">
		/// The number of <see cref="CardResponse"/>s per page. Should be less than or equal to 50. 
		/// (Will return at most 50 entries, even if count is greater than 50)
		/// </param>
        /// <param name="featured">Returns only featured cards.</param>
		/// <returns>A <see cref="CardsResponse"/> with cards of the specified user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
        CardsResponse GetUserCards(string screenName, int page, int count, bool featured = false);

		/// <summary>
		/// Retrieves the card with the given card id.
		/// </summary>
		/// <param name="cardId">The id of the card whose data is being requested.</param>
		/// <returns>A <see cref="CardResponse"/> with the specified id.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		CardResponse GetCard(string cardId);

		/// <summary>
		/// Creates a new card
		/// </summary>
		/// <param name="headline">The headline for the new card.</param>
		/// <returns>The created <see cref="CardResponse"/>.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		CardResponse CreateCard(string headline);

		/// <summary>
		/// Asynchronously retrieves the first 10 cards of the authenticated user.
		/// </summary>
        /// <param name="featured">Returns only featured cards.</param>
		/// <returns>A <see cref="CardsResponse"/> with cards of the authenticated user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		Task<CardsResponse> GetUserCardsAsync(bool featured = false);

		/// <summary>
		/// Asynchronously retrieves cards of the authenticated user.
		/// </summary>
		/// <param name="page">The page to return.</param>
		/// <param name="count">
		/// The number of <see cref="CardResponse"/>s per page. Should be less than or equal to 50. 
		/// (Will return at most 50 entries, even if count is greater than 50)
		/// </param>
        /// <param name="featured">Returns only featured cards.</param>
		/// <returns>A <see cref="CardsResponse"/> with cards of the authenticated user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
        Task<CardsResponse> GetUserCardsAsync(int page, int count, bool featured = false);

		/// <summary>
		/// Asynchronously retrieves the first 10 cards of the given user.
		/// </summary>
		/// <param name="screenName">The screen name of the user whose cards are being requested.</param>
        /// <param name="featured">Returns only featured cards.</param>
		/// <returns>A <see cref="CardsResponse"/> with cards of the specified user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
        Task<CardsResponse> GetUserCardsAsync(string screenName, bool featured = false);

		/// <summary>
		/// Asynchronously retrieves cards of the given user.
		/// </summary>
		/// <param name="screenName">The screen name of the user whose cards are being requested.</param>
		/// <param name="page">The page to return.</param>
		/// <param name="count">
		/// The number of <see cref="CardResponse"/>s per page. Should be less than or equal to 50. 
		/// (Will return at most 50 entries, even if count is greater than 50)
		/// </param>
        /// <param name="featured">Returns only featured cards.</param>
		/// <returns>A <see cref="CardsResponse"/> with cards of the specified user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
        Task<CardsResponse> GetUserCardsAsync(string screenName, int page, int count, bool featured = false);

		/// <summary>
		/// Asynchronously retrieves the card with the given card id.
		/// </summary>
		/// <param name="cardId">The id of the card whose data is being requested.</param>
		/// <returns>A <see cref="CardResponse"/> with the specified id.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		Task<CardResponse> GetCardAsync(string cardId);

		/// <summary>
		/// Asynchronously creates a new card
		/// </summary>
		/// <param name="headline">The headline for the new card.</param>
		/// <returns>The created <see cref="CardResponse"/>.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		Task<CardResponse> CreateCardAsync(string headline);
	}
}
