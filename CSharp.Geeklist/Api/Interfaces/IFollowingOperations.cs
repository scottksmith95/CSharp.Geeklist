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
	/// Interface defining the operations for searching Geeklist and retrieving following data.
	/// </summary>
	/// <author>Scott Smith</author>
	public interface IFollowingOperations
	{
		/// <summary>
		/// Retrieves the first 10 users the authenticating user is following.
		/// </summary>
		/// <returns>A <see cref="FollowingContainer"/> with users the authenticating user is following.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		/// <exception cref="GeeklistApiException">If OAuth credentials was not provided.</exception>
		FollowingContainer GetUserFollowing();

		/// <summary>
		/// Retrieves users the authenticating user is following.
		/// </summary>
		/// <param name="page">The page to return.</param>
		/// <param name="count">
		/// The number of <see cref="Following"/>s per page. Should be less than or equal to 50. 
		/// (Will return at most 50 entries, even if count is greater than 50)
		/// </param>
		/// <returns>A <see cref="FollowingContainer"/> with users the authenticating user is following.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		/// <exception cref="GeeklistApiException">If OAuth credentials was not provided.</exception>
		FollowingContainer GetUserFollowing(int page, int count);

		/// <summary>
		/// Retrieves the first 10 users the specified user is following.
		/// </summary>
		/// <param name="screenName">The screen name of the user to retrieve the list of users they are following.</param>
		/// <returns>A <see cref="FollowingContainer"/> with users the specified user is following.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		FollowingContainer GetUserFollowing(string screenName);

		/// <summary>
		/// Retrieves users the specified user is following.
		/// </summary>
		/// <param name="screenName">The screen name of the user to retrieve the list of users they are following.</param>
		/// <param name="page">The page to return.</param>
		/// <param name="count">
		/// The number of <see cref="Following"/>s per page. Should be less than or equal to 50. 
		/// (Will return at most 50 entries, even if count is greater than 50)
		/// </param>
		/// <returns>A <see cref="FollowingContainer"/> with users the specified user is following.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		FollowingContainer GetUserFollowing(string screenName, int page, int count);

		/// <summary>
		/// Asynchronously retrieves the first 10 users the authenticating user is following.
		/// </summary>
		/// <returns>A <see cref="FollowingContainer"/> with users the authenticating user is following.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		/// <exception cref="GeeklistApiException">If OAuth credentials was not provided.</exception>
		Task<FollowingContainer> GetUserFollowingAsync();

		/// <summary>
		/// Asynchronously retrieves users the authenticating user is following.
		/// </summary>
		/// <param name="page">The page to return.</param>
		/// <param name="count">
		/// The number of <see cref="Following"/>s per page. Should be less than or equal to 50. 
		/// (Will return at most 50 entries, even if count is greater than 50)
		/// </param>
		/// <returns>A <see cref="FollowingContainer"/> with users the authenticating user is following.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		/// <exception cref="GeeklistApiException">If OAuth credentials was not provided.</exception>
		Task<FollowingContainer> GetUserFollowingAsync(int page, int count);

		/// <summary>
		/// Asynchronously retrieves the first 10 users the specified user is following.
		/// </summary>
		/// <param name="screenName">The screen name of the user to retrieve the list of users they are following.</param>
		/// <returns>A <see cref="FollowingContainer"/> with users the specified user is following.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		Task<FollowingContainer> GetUserFollowingAsync(string screenName);

		/// <summary>
		/// Asynchronously retrieves users the specified user is following.
		/// </summary>
		/// <param name="screenName">The screen name of the user to retrieve the list of users they are following.</param>
		/// <param name="page">The page to return.</param>
		/// <param name="count">
		/// The number of <see cref="Following"/>s per page. Should be less than or equal to 50. 
		/// (Will return at most 50 entries, even if count is greater than 50)
		/// </param>
		/// <returns>A <see cref="FollowingContainer"/> with users the specified user is following.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		Task<FollowingContainer> GetUserFollowingAsync(string screenName, int page, int count);
	}
}
