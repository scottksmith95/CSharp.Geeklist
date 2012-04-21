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

using CSharp.Geeklist.Api.Models;
using Spring.Http;
using System.Threading.Tasks;

namespace CSharp.Geeklist.Api.Interfaces
{
	/// <summary>
	/// Interface defining the operations for Geeklist follower data.
	/// </summary>
	/// <author>Scott Smith</author>
	public interface IFollowerOperations
	{
		/// <summary>
		/// Retrieves the first 10 followers of the authenticated user.
		/// </summary>
		/// <returns>A <see cref="FollowersResponse"/> with followers of the authenticated user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		FollowersResponse GetUserFollowers();

		/// <summary>
		/// Retrieves followers of the authenticated user.
		/// </summary>
		/// <param name="page">The page to return.</param>
		/// <param name="count">
		/// The number of <see cref="FollowersResponse"/>s per page. Should be less than or equal to 50. 
		/// (Will return at most 50 entries, even if count is greater than 50)
		/// </param>
		/// <returns>A <see cref="FollowersResponse"/> with followers of the authenticated user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		FollowersResponse GetUserFollowers(int page, int count);

		/// <summary>
		/// Retrieves the first 10 followers of the given user.
		/// </summary>
		/// <param name="screenName">The screen name of the user whose followers are being requested.</param>
		/// <returns>A <see cref="FollowersResponse"/> with followers of the specified user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		FollowersResponse GetUserFollowers(string screenName);

		/// <summary>
		/// Retrieves followers of the given user.
		/// </summary>
		/// <param name="screenName">The screen name of the user whose followers are being requested.</param>
		/// <param name="page">The page to return.</param>
		/// <param name="count">
		/// The number of <see cref="FollowersResponse"/>s per page. Should be less than or equal to 50. 
		/// (Will return at most 50 entries, even if count is greater than 50)
		/// </param>
		/// <returns>A <see cref="FollowersResponse"/> with followers of the specified user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		FollowersResponse GetUserFollowers(string screenName, int page, int count);

		/// <summary>
		/// Start following the given user
		/// </summary>
		/// <param name="userId">The id of the user to start following.</param>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		HttpResponseMessage StartFollowing(string userId);

		/// <summary>
		/// Stop following the given user
		/// </summary>
		/// <param name="userId">The id of the user to stop following.</param>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		HttpResponseMessage StopFollowing(string userId);

		/// <summary>
		/// Asynchronously retrieves the first 10 followers of the authenticated user.
		/// </summary>
		/// <returns>A <see cref="FollowersResponse"/> with followers of the authenticated user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		Task<FollowersResponse> GetUserFollowersAsync();

		/// <summary>
		/// Asynchronously retrieves followers of the authenticated user.
		/// </summary>
		/// <param name="page">The page to return.</param>
		/// <param name="count">
		/// The number of <see cref="FollowersResponse"/>s per page. Should be less than or equal to 50. 
		/// (Will return at most 50 entries, even if count is greater than 50)
		/// </param>
		/// <returns>A <see cref="FollowersResponse"/> with followers of the authenticated user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		Task<FollowersResponse> GetUserFollowersAsync(int page, int count);

		/// <summary>
		/// Asynchronously retrieves the first 10 followers of the given user.
		/// </summary>
		/// <param name="screenName">The screen name of the user whose followers are being requested.</param>
		/// <returns>A <see cref="FollowersResponse"/> with followers of the specified user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		Task<FollowersResponse> GetUserFollowersAsync(string screenName);

		/// <summary>
		/// Asynchronously retrieves followers of the given user.
		/// </summary>
		/// <param name="screenName">The screen name of the user whose followers are being requested.</param>
		/// <param name="page">The page to return.</param>
		/// <param name="count">
		/// The number of <see cref="FollowersResponse"/>s per page. Should be less than or equal to 50. 
		/// (Will return at most 50 entries, even if count is greater than 50)
		/// </param>
		/// <returns>A <see cref="FollowersResponse"/> with followers of the specified user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		Task<FollowersResponse> GetUserFollowersAsync(string screenName, int page, int count);

		/// <summary>
		/// Asynchronously start following the given user
		/// </summary>
		/// <param name="userId">The id of the user to start following.</param>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		Task<HttpResponseMessage> StartFollowingAsync(string userId);

		/// <summary>
		/// Asynchronously stop following the given user
		/// </summary>
		/// <param name="userId">The id of the user to stop following.</param>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		Task<HttpResponseMessage> StopFollowingAsync(string userId);
	}
}
