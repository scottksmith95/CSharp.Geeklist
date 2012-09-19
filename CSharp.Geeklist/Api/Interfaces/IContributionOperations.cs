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
	/// Interface defining the operations for Geeklist contribution data.
	/// </summary>
	/// <author>Scott Smith</author>
	public interface IContributionOperations
	{
		/// <summary>
		/// Retrieves the first 10 contributions of the authenticated user.
		/// </summary>
		/// <returns>A <see cref="CardsResponse"/> with contributions of the authenticated user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		CardsResponse GetUserContributions();

		/// <summary>
		/// Retrieves contributions of the authenticated user.
		/// </summary>
		/// <param name="page">The page to return.</param>
		/// <param name="count">
		/// The number of <see cref="CardResponse"/>s per page. Should be less than or equal to 50. 
		/// (Will return at most 50 entries, even if count is greater than 50)
		/// </param>
		/// <returns>A <see cref="CardsResponse"/> with contributions of the authenticated user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		CardsResponse GetUserContributions(int page, int count);

		/// <summary>
		/// Retrieves the first 10 contributions of the given user.
		/// </summary>
		/// <param name="screenName">The screen name of the user whose contributions are being requested.</param>
		/// <returns>A <see cref="CardsResponse"/> with contributions of the specified user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		CardsResponse GetUserContributions(string screenName);

		/// <summary>
		/// Retrieves contributions of the given user.
		/// </summary>
		/// <param name="screenName">The screen name of the user whose contributions are being requested.</param>
		/// <param name="page">The page to return.</param>
		/// <param name="count">
		/// The number of <see cref="CardResponse"/>s per page. Should be less than or equal to 50. 
		/// (Will return at most 50 entries, even if count is greater than 50)
		/// </param>
		/// <returns>A <see cref="CardsResponse"/> with contributions of the specified user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		CardsResponse GetUserContributions(string screenName, int page, int count);

		/// <summary>
		/// Asynchronously retrieves the first 10 contributions of the authenticated user.
		/// </summary>
		/// <returns>A <see cref="CardsResponse"/> with contributions of the authenticated user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		Task<CardsResponse> GetUserContributionsAsync();

		/// <summary>
		/// Asynchronously retrieves contributions of the authenticated user.
		/// </summary>
		/// <param name="page">The page to return.</param>
		/// <param name="count">
		/// The number of <see cref="CardResponse"/>s per page. Should be less than or equal to 50. 
		/// (Will return at most 50 entries, even if count is greater than 50)
		/// </param>
		/// <returns>A <see cref="CardsResponse"/> with contributions of the authenticated user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		Task<CardsResponse> GetUserContributionsAsync(int page, int count);

		/// <summary>
		/// Asynchronously retrieves the first 10 contributions of the given user.
		/// </summary>
		/// <param name="screenName">The screen name of the user whose contributions are being requested.</param>
		/// <returns>A <see cref="CardsResponse"/> with contributions of the specified user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		Task<CardsResponse> GetUserContributionsAsync(string screenName);

		/// <summary>
		/// Asynchronously retrieves contributions of the given user.
		/// </summary>
		/// <param name="screenName">The screen name of the user whose contributions are being requested.</param>
		/// <param name="page">The page to return.</param>
		/// <param name="count">
		/// The number of <see cref="CardResponse"/>s per page. Should be less than or equal to 50. 
		/// (Will return at most 50 entries, even if count is greater than 50)
		/// </param>
		/// <returns>A <see cref="CardsResponse"/> with contributions of the specified user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		Task<CardsResponse> GetUserContributionsAsync(string screenName, int page, int count);
	}
}
