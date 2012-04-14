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

using System.Collections.Generic;
using System.Threading.Tasks;
using CSharp.Geeklist.Api.Models;

namespace CSharp.Geeklist.Api.Interfaces
{
	/// <summary>
	/// Interface defining the operations for searching Geeklist and retrieving activity data.
	/// </summary>
	/// <author>Scott Smith</author>
	public interface IActivityOperations
	{
		/// <summary>
		/// Retrieves the first 10 activities of the authenticating user.
		/// </summary>
		/// <returns>A list of <see cref="Activity"/> of the authenticating user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		/// <exception cref="GeeklistApiException">If OAuth credentials was not provided.</exception>
		IList<Activity> GetUserActivities();

		/// <summary>
		/// Retrieves activities of the authenticating user.
		/// </summary>
		/// <param name="page">The page to return.</param>
		/// <param name="count">
		/// The number of <see cref="Activity"/> per page. Should be less than or equal to 50. 
		/// (Will return at most 50 entries, even if count is greater than 50)
		/// </param>
		/// <returns>A list of <see cref="Activity"/> of the authenticating user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		/// <exception cref="GeeklistApiException">If OAuth credentials was not provided.</exception>
		IList<Activity> GetUserActivities(int page, int count);

		/// <summary>
		/// Retrieves the first 10 activities of the given user.
		/// </summary>
		/// <param name="screenName">The screen name of the user whose activity is being requested.</param>
		/// <returns>A list of <see cref="Activity"/> of the specified user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		IList<Activity> GetUserActivities(string screenName);

		/// <summary>
		/// Retrieves activities of the given user.
		/// </summary>
		/// <param name="screenName">The screen name of the user whose activity is being requested.</param>
		/// <param name="page">The page to return.</param>
		/// <param name="count">
		/// The number of <see cref="Activity"/> per page. Should be less than or equal to 50. 
		/// (Will return at most 50 entries, even if count is greater than 50)
		/// </param>
		/// <returns>A list of <see cref="Activity"/> of the specified user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		IList<Activity> GetUserActivities(string screenName, int page, int count);

		/// <summary>
		/// Retrieves the first 10 activities from all users
		/// </summary>
		/// <returns>A list of <see cref="Activity"/> of all users.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		IList<Activity> GetAllActivities();

		/// <summary>
		/// Retrieves activities from all users.
		/// </summary>
		/// <param name="page">The page to return.</param>
		/// <param name="count">
		/// The number of <see cref="Activity"/> per page. Should be less than or equal to 50. 
		/// (Will return at most 50 entries, even if count is greater than 50)
		/// </param>
		/// <returns>A list of <see cref="Activity"/> of all users.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		IList<Activity> GetAllActivities(int page, int count);

		/// <summary>
		/// Asynchronously retrieves the first 10 activities of the authenticating user.
		/// </summary>
		/// <returns>A list of <see cref="Activity"/> of the authenticating user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		/// <exception cref="GeeklistApiException">If OAuth credentials was not provided.</exception>
		Task<IList<Activity>> GetUserActivitiesAsync();

		/// <summary>
		/// Asynchronously retrieves activities of the authenticating user.
		/// </summary>
		/// <param name="page">The page to return.</param>
		/// <param name="count">
		/// The number of <see cref="Activity"/> per page. Should be less than or equal to 50. 
		/// (Will return at most 50 entries, even if count is greater than 50)
		/// </param>
		/// <returns>A list of <see cref="Activity"/> of the authenticating user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		/// <exception cref="GeeklistApiException">If OAuth credentials was not provided.</exception>
		Task<IList<Activity>> GetUserActivitiesAsync(int page, int count);

		/// <summary>
		/// Asynchronously retrieves the first 10 activities of the given user.
		/// </summary>
		/// <param name="screenName">The screen name of the user whose activity is being requested.</param>
		/// <returns>A list of <see cref="Activity"/> of the specified user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		Task<IList<Activity>> GetUserActivitiesAsync(string screenName);

		/// <summary>
		/// Retrieves activities of the given user.
		/// </summary>
		/// <param name="screenName">The screen name of the user whose activity is being requested.</param>
		/// <param name="page">The page to return.</param>
		/// <param name="count">
		/// The number of <see cref="Activity"/> per page. Should be less than or equal to 50. 
		/// (Will return at most 50 entries, even if count is greater than 50)
		/// </param>
		/// <returns>A list of <see cref="Activity"/> of the specified user.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		Task<IList<Activity>> GetUserActivitiesAsync(string screenName, int page, int count);

		/// <summary>
		/// Asynchronously retrieves the first 10 activities from all users
		/// </summary>
		/// <returns>A list of <see cref="Activity"/> of all users.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		Task<IList<Activity>> GetAllActivitiesAsync();

		/// <summary>
		/// Asynchronously retrieves activities from all users.
		/// </summary>
		/// <param name="page">The page to return.</param>
		/// <param name="count">
		/// The number of <see cref="Activity"/> per page. Should be less than or equal to 50. 
		/// (Will return at most 50 entries, even if count is greater than 50)
		/// </param>
		/// <returns>A list of <see cref="Activity"/> of all users.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		Task<IList<Activity>> GetAllActivitiesAsync(int page, int count);
	}
}
