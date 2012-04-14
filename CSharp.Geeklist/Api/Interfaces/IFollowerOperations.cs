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
	/// Interface defining the operations for searching Geeklist and retrieving follower data.
	/// </summary>
	/// <author>Scott Smith</author>
	public interface IFollowerOperations
	{
		/// <summary>
		/// Retrieves the first 10 followers of the authenticating user.
		/// </summary>
		/// <returns>A <see cref="FollowerContainer"/> with followers of the authenticating user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		/// <exception cref="GeeklistApiException">If OAuth credentials was not provided.</exception>
		FollowerContainer GetUserFollowers();

		/// <summary>
		/// Retrieves followers of the authenticating user.
		/// </summary>
		/// <param name="page">The page to return.</param>
		/// <param name="count">
		/// The number of <see cref="Follower"/>s per page. Should be less than or equal to 50. 
		/// (Will return at most 50 entries, even if count is greater than 50)
		/// </param>
		/// <returns>A <see cref="FollowerContainer"/> with followers of the authenticating user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		/// <exception cref="GeeklistApiException">If OAuth credentials was not provided.</exception>
		FollowerContainer GetUserFollowers(int page, int count);

		/// <summary>
		/// Retrieves the first 10 followers of the given user.
		/// </summary>
		/// <param name="screenName">The screen name of the user whose followers are being requested.</param>
		/// <returns>A <see cref="FollowerContainer"/> with followers of the specified user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		FollowerContainer GetUserFollowers(string screenName);

		/// <summary>
		/// Retrieves followers of the given user.
		/// </summary>
		/// <param name="screenName">The screen name of the user whose followers are being requested.</param>
		/// <param name="page">The page to return.</param>
		/// <param name="count">
		/// The number of <see cref="Follower"/>s per page. Should be less than or equal to 50. 
		/// (Will return at most 50 entries, even if count is greater than 50)
		/// </param>
		/// <returns>A <see cref="FollowerContainer"/> with followers of the specified user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		FollowerContainer GetUserFollowers(string screenName, int page, int count);

		/// <summary>
		/// Follows the given user for the authenticating user
		/// </summary>
		/// <param name="userId">The id of the user to follow.</param>
		/// <exception cref="GeekListApiException">If there is an error while communicating with Geeklist.</exception>
		/// <exception cref="GeekListApiException">If OAuth credentials was not provided.</exception>
		HttpResponseMessage Follow(string userId);

		/// <summary>
		/// UnFollows the given user for the authenticating user
		/// </summary>
		/// <param name="userId">The id of the user to unfollow.</param>
		/// <exception cref="GeekListApiException">If there is an error while communicating with Geeklist.</exception>
		/// <exception cref="GeekListApiException">If OAuth credentials was not provided.</exception>
		HttpResponseMessage UnFollow(string userId);

		/// <summary>
		/// Asynchronously retrieves the first 10 followers of the authenticating user.
		/// </summary>
		/// <returns>A <see cref="FollowerContainer"/> with followers of the authenticating user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		/// <exception cref="GeeklistApiException">If OAuth credentials was not provided.</exception>
		Task<FollowerContainer> GetUserFollowersAsync();

		/// <summary>
		/// Asynchronously retrieves followers of the authenticating user.
		/// </summary>
		/// <param name="page">The page to return.</param>
		/// <param name="count">
		/// The number of <see cref="Follower"/>s per page. Should be less than or equal to 50. 
		/// (Will return at most 50 entries, even if count is greater than 50)
		/// </param>
		/// <returns>A <see cref="FollowerContainer"/> with followers of the authenticating user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		/// <exception cref="GeeklistApiException">If OAuth credentials was not provided.</exception>
		Task<FollowerContainer> GetUserFollowersAsync(int page, int count);

		/// <summary>
		/// Asynchronously retrieves the first 10 followers of the given user.
		/// </summary>
		/// <param name="screenName">The screen name of the user whose followers are being requested.</param>
		/// <returns>A <see cref="FollowerContainer"/> with followers of the specified user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		Task<FollowerContainer> GetUserFollowersAsync(string screenName);

		/// <summary>
		/// Asynchronously retrieves followers of the given user.
		/// </summary>
		/// <param name="screenName">The screen name of the user whose followers are being requested.</param>
		/// <param name="page">The page to return.</param>
		/// <param name="count">
		/// The number of <see cref="Follower"/>s per page. Should be less than or equal to 50. 
		/// (Will return at most 50 entries, even if count is greater than 50)
		/// </param>
		/// <returns>A <see cref="FollowerContainer"/> with followers of the specified user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		Task<FollowerContainer> GetUserFollowersAsync(string screenName, int page, int count);

		/// <summary>
		/// Asynchronously follows the given user for the authenticating user
		/// </summary>
		/// <param name="userId">The id of the user to follow.</param>
		/// <exception cref="GeekListApiException">If there is an error while communicating with Geeklist.</exception>
		/// <exception cref="GeekListApiException">If OAuth credentials was not provided.</exception>
		Task<HttpResponseMessage> FollowAsync(string userId);

		/// <summary>
		/// Asynchronously unfollows the given user for the authenticating user
		/// </summary>
		/// <param name="userId">The id of the user to unfollow.</param>
		/// <exception cref="GeekListApiException">If there is an error while communicating with Geeklist.</exception>
		/// <exception cref="GeekListApiException">If OAuth credentials was not provided.</exception>
		Task<HttpResponseMessage> UnFollowAsync(string userId);
	}
}
