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
using CSharp.Geeklist.Api.Enums;
using CSharp.Geeklist.Api.Models;

namespace CSharp.Geeklist.Api.Interfaces
{
	/// <summary>
	/// Interface defining the operations for Geeklist activity data.
	/// </summary>
	/// <author>Scott Smith</author>
	public interface IActivityOperations
	{
		/// <summary>
		/// Retrieves the first 10 activities of the authenticated user.
		/// </summary>
		/// <returns><see cref="ActivitiesResponse"/> of the authenticated user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		ActivitiesResponse GetUserActivities();

		/// <summary>
		/// Retrieves activities of the authenticated user.
		/// </summary>
		/// <param name="page">The page to return.</param>
		/// <param name="count">
		/// The number of <see cref="ActivitiesResponse"/> per page. Should be less than or equal to 50. 
		/// (Will return at most 50 entries, even if count is greater than 50)
		/// </param>
		/// <returns><see cref="ActivitiesResponse"/> of the authenticated user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		ActivitiesResponse GetUserActivities(int page, int count);

		/// <summary>
		/// Retrieves the first 10 activities of the given user.
		/// </summary>
		/// <param name="screenName">The screen name of the user whose activities are being requested.</param>
		/// <returns><see cref="ActivitiesResponse"/> of the specified user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		ActivitiesResponse GetUserActivities(string screenName);

		/// <summary>
		/// Retrieves activities of the given user.
		/// </summary>
		/// <param name="screenName">The screen name of the user whose activities are being requested.</param>
		/// <param name="page">The page to return.</param>
		/// <param name="count">
		/// The number of <see cref="ActivitiesResponse"/> per page. Should be less than or equal to 50. 
		/// (Will return at most 50 entries, even if count is greater than 50)
		/// </param>
		/// <returns><see cref="ActivitiesResponse"/> of the specified user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		ActivitiesResponse GetUserActivities(string screenName, int page, int count);

		/// <summary>
		/// Retrieves the first 10 activities from all users
		/// </summary>
		/// <param name="filter">The filter of activities to return.</param>
        /// <param name="feed">The activity feed to return.</param>
        /// <param name="hash">Hash will give you only micros that contain the hash (gklst) from the discovery feed.</param>
        /// <param name="start">Since the activity feeds are sorted descending by date, you can specify a starting activity id and fetch any activities older than that id with the limit you set.</param>
		/// <returns><see cref="ActivitiesResponse"/> of all users.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		ActivitiesResponse GetAllActivities(FilterType filter = FilterType.All, FeedType feed = FeedType.AuthenticatedUser, string hash = null, string start = null);

		/// <summary>
		/// Retrieves activities from all users.
		/// </summary>
		/// <param name="page">The page to return.</param>
		/// <param name="count">
		/// The number of <see cref="ActivitiesResponse"/> per page. Should be less than or equal to 50. 
		/// (Will return at most 50 entries, even if count is greater than 50)
		/// </param>
		/// <param name="filter">The filter of activities to return.</param>
        /// <param name="feed">The activity feed to return.</param>
        /// <param name="hash">Hash will give you only micros that contain the hash (gklst) from the discovery feed.</param>
        /// <param name="start">Since the activity feeds are sorted descending by date, you can specify a starting activity id and fetch any activities older than that id with the limit you set.</param>
		/// <returns><see cref="ActivitiesResponse"/> of all users.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
        ActivitiesResponse GetAllActivities(int page, int count, FilterType filter = FilterType.All, FeedType feed = FeedType.AuthenticatedUser, string hash = null, string start = null);

		/// <summary>
		/// Asynchronously retrieves the first 10 activities of the authenticated user.
		/// </summary>
		/// <returns><see cref="ActivitiesResponse"/> of the authenticated user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		Task<ActivitiesResponse> GetUserActivitiesAsync();

		/// <summary>
		/// Asynchronously retrieves activities of the authenticated user.
		/// </summary>
		/// <param name="page">The page to return.</param>
		/// <param name="count">
		/// The number of <see cref="ActivitiesResponse"/> per page. Should be less than or equal to 50. 
		/// (Will return at most 50 entries, even if count is greater than 50)
		/// </param>
		/// <returns><see cref="ActivitiesResponse"/> of the authenticated user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		Task<ActivitiesResponse> GetUserActivitiesAsync(int page, int count);

		/// <summary>
		/// Asynchronously retrieves the first 10 activities of the given user.
		/// </summary>
		/// <param name="screenName">The screen name of the user whose activities are being requested.</param>
		/// <returns><see cref="ActivitiesResponse"/> of the specified user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		Task<ActivitiesResponse> GetUserActivitiesAsync(string screenName);

		/// <summary>
		/// Asynchronously retrieves activities of the given user.
		/// </summary>
		/// <param name="screenName">The screen name of the user whose activities are being requested.</param>
		/// <param name="page">The page to return.</param>
		/// <param name="count">
		/// The number of <see cref="ActivitiesResponse"/> per page. Should be less than or equal to 50. 
		/// (Will return at most 50 entries, even if count is greater than 50)
		/// </param>
		/// <returns><see cref="ActivitiesResponse"/> of the specified user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		Task<ActivitiesResponse> GetUserActivitiesAsync(string screenName, int page, int count);

		/// <summary>
		/// Asynchronously retrieves the first 10 activities from all users
		/// </summary>
		/// <param name="filter">The filter of activities to return.</param>
        /// <param name="feed">The activity feed to return.</param>
        /// <param name="hash">Hash will give you only micros that contain the hash (gklst) from the discovery feed.</param>
        /// <param name="start">Since the activity feeds are sorted descending by date, you can specify a starting activity id and fetch any activities older than that id with the limit you set.</param>
		/// <returns><see cref="ActivitiesResponse"/> of all users.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
        Task<ActivitiesResponse> GetAllActivitiesAsync(FilterType filter = FilterType.All, FeedType feed = FeedType.AuthenticatedUser, string hash = null, string start = null);

		/// <summary>
		/// Asynchronously retrieves activities from all users.
		/// </summary>
		/// <param name="page">The page to return.</param>
		/// <param name="count">
		/// The number of <see cref="ActivitiesResponse"/> per page. Should be less than or equal to 50. 
		/// (Will return at most 50 entries, even if count is greater than 50)
		/// </param>
		/// <param name="filter">The filter of activities to return.</param>
        /// <param name="feed">The activity feed to return.</param>
        /// <param name="hash">Hash will give you only micros that contain the hash (gklst) from the discovery feed.</param>
        /// <param name="start">Since the activity feeds are sorted descending by date, you can specify a starting activity id and fetch any activities older than that id with the limit you set.</param>
		/// <returns><see cref="ActivitiesResponse"/> of all users.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
        Task<ActivitiesResponse> GetAllActivitiesAsync(int page, int count, FilterType filter = FilterType.All, FeedType feed = FeedType.AuthenticatedUser, string hash = null, string start = null);
	}
}
