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
	/// Interface defining the operations for searching Geeklist and retrieving micro data.
	/// </summary>
	/// <author>Scott Smith</author>
	public interface IMicroOperations
	{
		/// <summary>
		/// Retrieves the first 10 micros of the authenticating user.
		/// </summary>
		/// <returns>A <see cref="MicroContainer"/> with micros of the authenticating user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		/// <exception cref="GeeklistApiException">If OAuth credentials was not provided.</exception>
		MicroContainer GetUserMicros();

		/// <summary>
		/// Retrieves micros of the authenticating user.
		/// </summary>
		/// <param name="page">The page to return.</param>
		/// <param name="count">
		/// The number of <see cref="Micro"/>s per page. Should be less than or equal to 50. 
		/// (Will return at most 50 entries, even if count is greater than 50)
		/// </param>
		/// <returns>A <see cref="MicroContainer"/> with micros of the authenticating user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		/// <exception cref="GeeklistApiException">If OAuth credentials was not provided.</exception>
		MicroContainer GetUserMicros(int page, int count);

		/// <summary>
		/// Retrieves the first 10 micros of the given user.
		/// </summary>
		/// <param name="screenName">The screen name of the user whose micros are being requested.</param>
		/// <returns>A <see cref="MicroContainer"/> with micros of the specified user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		MicroContainer GetUserMicros(string screenName);

		/// <summary>
		/// Retrieves micros of the given user.
		/// </summary>
		/// <param name="screenName">The screen name of the user whose micros are being requested.</param>
		/// <param name="page">The page to return.</param>
		/// <param name="count">
		/// The number of <see cref="Micro"/>s per page. Should be less than or equal to 50. 
		/// (Will return at most 50 entries, even if count is greater than 50)
		/// </param>
		/// <returns>A <see cref="MicroContainer"/> with micros of the specified user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		MicroContainer GetUserMicros(string screenName, int page, int count);

		/// <summary>
		/// Retrieves the micro with the given micro id.
		/// </summary>
		/// <param name="microId">The id of the micro whose data is being requested.</param>
		/// <returns>A <see cref="Micro"/> with the specified id.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		Micro GetMicro(string microId);

		/// <summary>
		/// Creates a new micro for the authenticating user
		/// </summary>
		/// <param name="status">The content for the micro.</param>
		/// <returns>The created <see cref="Micro"/>.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		/// <exception cref="GeeklistApiException">If OAuth credentials was not provided.</exception>
		Micro CreateMicro(string status);

		/// <summary>
		/// Creates a new micro for the authenticating user
		/// </summary>
		/// <param name="status">The content for the micro.</param>
		/// <param name="type">The type of item being replied to. Can be card or micro.</param>
		/// <param name="inReplyToId">The id of the card or micro being replied to.</param>
		/// <returns>The created <see cref="Micro"/>.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		/// <exception cref="GeeklistApiException">If OAuth credentials was not provided.</exception>
		Micro CreateMicro(string status, string type, string inReplyToId);

		/// <summary>
		/// Asynchronously retrieves the first 10 micros of the authenticating user.
		/// </summary>
		/// <returns>A <see cref="MicroContainer"/> with micros of the authenticating user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		/// <exception cref="GeeklistApiException">If OAuth credentials was not provided.</exception>
		Task<MicroContainer> GetUserMicrosAsync();

		/// <summary>
		/// Asynchronously retrieves micros of the authenticating user.
		/// </summary>
		/// <param name="page">The page to return.</param>
		/// <param name="count">
		/// The number of <see cref="Micro"/>s per page. Should be less than or equal to 50. 
		/// (Will return at most 50 entries, even if count is greater than 50)
		/// </param>
		/// <returns>A <see cref="MicroContainer"/> with micros of the authenticating user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		/// <exception cref="GeeklistApiException">If OAuth credentials was not provided.</exception>
		Task<MicroContainer> GetUserMicrosAsync(int page, int count);

		/// <summary>
		/// Asynchronously retrieves the first 10 micros of the given user.
		/// </summary>
		/// <param name="screenName">The screen name of the user whose micros are being requested.</param>
		/// <returns>A <see cref="MicroContainer"/> with micros of the specified user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		Task<MicroContainer> GetUserMicrosAsync(string screenName);

		/// <summary>
		/// Asynchronously retrieves micros of the given user.
		/// </summary>
		/// <param name="screenName">The screen name of the user whose micros are being requested.</param>
		/// <param name="page">The page to return.</param>
		/// <param name="count">
		/// The number of <see cref="Micro"/>s per page. Should be less than or equal to 50. 
		/// (Will return at most 50 entries, even if count is greater than 50)
		/// </param>
		/// <returns>A <see cref="MicroContainer"/> with micros of the specified user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		Task<MicroContainer> GetUserMicrosAsync(string screenName, int page, int count);

		/// <summary>
		/// Asynchronously retrieves the micro with the given micro id.
		/// </summary>
		/// <param name="microId">The id of the micro whose data is being requested.</param>
		/// <returns>A <see cref="Micro"/> with the specified id.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		Task<Micro> GetMicroAsync(string microId);

		/// <summary>
		/// Asynchronously creates a new micro for the authenticating user
		/// </summary>
		/// <param name="status">The content for the micro.</param>
		/// <returns>The created <see cref="Micro"/>.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		/// <exception cref="GeeklistApiException">If OAuth credentials was not provided.</exception>
		Task<Micro> CreateMicroAsync(string status);

		/// <summary>
		/// Asynchronously creates a new micro for the authenticating user
		/// </summary>
		/// <param name="status">The content for the micro.</param>
		/// <param name="type">The type of item being replied to. Can be card or micro.</param>
		/// <param name="inReplyToId">The id of the card or micro being replied to.</param>
		/// <returns>The created <see cref="Micro"/>.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		/// <exception cref="GeeklistApiException">If OAuth credentials was not provided.</exception>
		Task<Micro> CreateMicroAsync(string status, string type, string inReplyToId);
	}
}
