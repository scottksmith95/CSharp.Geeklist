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
		/// <param name="type">The type of activities to return.</param>
		/// <returns><see cref="ActivitiesResponse"/> of the authenticated user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		ActivitiesResponse GetUserActivities(ActivityType type = ActivityType.All);

		/// <summary>
		/// Retrieves activities of the authenticated user.
		/// </summary>
		/// <param name="page">The page to return.</param>
		/// <param name="count">
		/// The number of <see cref="ActivitiesResponse"/> per page. Should be less than or equal to 50. 
		/// (Will return at most 50 entries, even if count is greater than 50)
		/// </param>
		/// <param name="type">The type of activities to return.</param>
		/// <returns><see cref="ActivitiesResponse"/> of the authenticated user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		ActivitiesResponse GetUserActivities(int page, int count, ActivityType type = ActivityType.All);

		/// <summary>
		/// Retrieves the first 10 activities of the given user.
		/// </summary>
		/// <param name="screenName">The screen name of the user whose activities are being requested.</param>
		/// <param name="type">The type of activities to return.</param>
		/// <returns><see cref="ActivitiesResponse"/> of the specified user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		ActivitiesResponse GetUserActivities(string screenName, ActivityType type = ActivityType.All);

		/// <summary>
		/// Retrieves activities of the given user.
		/// </summary>
		/// <param name="screenName">The screen name of the user whose activities are being requested.</param>
		/// <param name="page">The page to return.</param>
		/// <param name="count">
		/// The number of <see cref="ActivitiesResponse"/> per page. Should be less than or equal to 50. 
		/// (Will return at most 50 entries, even if count is greater than 50)
		/// </param>
		/// <param name="type">The type of activities to return.</param>
		/// <returns><see cref="ActivitiesResponse"/> of the specified user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		ActivitiesResponse GetUserActivities(string screenName, int page, int count, ActivityType type = ActivityType.All);

		/// <summary>
		/// Retrieves the first 10 activities from all users
		/// </summary>
		/// <param name="type">The type of activities to return.</param>
		/// <returns><see cref="ActivitiesResponse"/> of all users.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		ActivitiesResponse GetAllActivities(ActivityType type = ActivityType.All);

		/// <summary>
		/// Retrieves activities from all users.
		/// </summary>
		/// <param name="page">The page to return.</param>
		/// <param name="count">
		/// The number of <see cref="ActivitiesResponse"/> per page. Should be less than or equal to 50. 
		/// (Will return at most 50 entries, even if count is greater than 50)
		/// </param>
		/// <param name="type">The type of activities to return.</param>
		/// <returns><see cref="ActivitiesResponse"/> of all users.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		ActivitiesResponse GetAllActivities(int page, int count, ActivityType type = ActivityType.All);

		/// <summary>
		/// Asynchronously retrieves the first 10 activities of the authenticated user.
		/// </summary>
		/// <returns><see cref="ActivitiesResponse"/> of the authenticated user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		Task<ActivitiesResponse> GetUserActivitiesAsync(ActivityType type = ActivityType.All);

		/// <summary>
		/// Asynchronously retrieves activities of the authenticated user.
		/// </summary>
		/// <param name="page">The page to return.</param>
		/// <param name="count">
		/// The number of <see cref="ActivitiesResponse"/> per page. Should be less than or equal to 50. 
		/// (Will return at most 50 entries, even if count is greater than 50)
		/// </param>
		/// <param name="type">The type of activities to return.</param>
		/// <returns><see cref="ActivitiesResponse"/> of the authenticated user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		Task<ActivitiesResponse> GetUserActivitiesAsync(int page, int count, ActivityType type = ActivityType.All);

		/// <summary>
		/// Asynchronously retrieves the first 10 activities of the given user.
		/// </summary>
		/// <param name="screenName">The screen name of the user whose activities are being requested.</param>
		/// <param name="type">The type of activities to return.</param>
		/// <returns><see cref="ActivitiesResponse"/> of the specified user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		Task<ActivitiesResponse> GetUserActivitiesAsync(string screenName, ActivityType type = ActivityType.All);

		/// <summary>
		/// Asynchronously retrieves activities of the given user.
		/// </summary>
		/// <param name="screenName">The screen name of the user whose activities are being requested.</param>
		/// <param name="page">The page to return.</param>
		/// <param name="count">
		/// The number of <see cref="ActivitiesResponse"/> per page. Should be less than or equal to 50. 
		/// (Will return at most 50 entries, even if count is greater than 50)
		/// </param>
		/// <param name="type">The type of activities to return.</param>
		/// <returns><see cref="ActivitiesResponse"/> of the specified user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		Task<ActivitiesResponse> GetUserActivitiesAsync(string screenName, int page, int count, ActivityType type = ActivityType.All);

		/// <summary>
		/// Asynchronously retrieves the first 10 activities from all users
		/// </summary>
		/// <param name="type">The type of activities to return.</param>
		/// <returns><see cref="ActivitiesResponse"/> of all users.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		Task<ActivitiesResponse> GetAllActivitiesAsync(ActivityType type = ActivityType.All);

		/// <summary>
		/// Asynchronously retrieves activities from all users.
		/// </summary>
		/// <param name="page">The page to return.</param>
		/// <param name="count">
		/// The number of <see cref="ActivitiesResponse"/> per page. Should be less than or equal to 50. 
		/// (Will return at most 50 entries, even if count is greater than 50)
		/// </param>
		/// <param name="type">The type of activities to return.</param>
		/// <returns><see cref="ActivitiesResponse"/> of all users.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		Task<ActivitiesResponse> GetAllActivitiesAsync(int page, int count, ActivityType type = ActivityType.All);
	}
}
