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
    /// Interface defining the operations for searching Geeklist and retrieving user data.
    /// </summary>
    /// <author>Scott Smith</author>
    public interface IUserOperations
    {
		/// <summary>
        /// Retrieves the authenticated user's Geeklist profile details.
	    /// </summary>
        /// <returns>A <see cref="User"/>object representing the user's profile.</returns>
        /// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
        /// <exception cref="GeeklistApiException">If OAuth credentials was not provided.</exception>
	    User GetUser();

        /// <summary>
        /// Retrieves a specific user's Geeklist profile details. 
        /// </summary>
        /// <param name="screenName">The screen name for the user whose details are to be retrieved.</param>
        /// <returns>A <see cref="User"/> object representing the user's profile.</returns>
        /// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
	    User GetUser(string screenName);

		/// <summary>
		/// Asynchronously retrieves the authenticated user's Geeklist profile details.
		/// </summary>
		/// <returns>A <see cref="User"/>object representing the user's profile.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		/// <exception cref="GeeklistApiException">If OAuth credentials was not provided.</exception>
		Task<User> GetUserAsync();

		/// <summary>
		/// Asynchronously retrieves a specific user's Geeklist profile details. 
		/// </summary>
		/// <param name="screenName">The screen name for the user whose details are to be retrieved.</param>
		/// <returns>A <see cref="User"/> object representing the user's profile.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		Task<User> GetUserAsync(string screenName);
    }
}
