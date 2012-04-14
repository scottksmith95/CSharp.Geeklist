﻿#region License

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

using Spring.Social.OAuth1;
using Spring.Social.Geeklist.Api;
using Spring.Social.Geeklist.Api.Impl;

namespace Spring.Social.Geeklist.Connect
{
    /// <summary>
	/// Geeklist <see cref="IServiceProvider"/> implementation.
    /// </summary>
    /// <author>Scott Smith</author>
	public class GeeklistServiceProvider : AbstractOAuth1ServiceProvider<IGeeklist>
    {
        /// <summary>
		/// Creates a new instance of <see cref="GeeklistServiceProvider"/>.
        /// </summary>
        /// <param name="consumerKey">The application's API key.</param>
        /// <param name="consumerSecret">The application's API secret.</param>
		public GeeklistServiceProvider(string consumerKey, string consumerSecret)
            : base(consumerKey, consumerSecret, new OAuth1Template(consumerKey, consumerSecret,
				"http://api.geekli.st/v1/oauth/request_token",
				"http://geekli.st/oauth/authorize",
				"http://api.geekli.st/v1/oauth/access_token"))
        {
        }

        /// <summary>
        /// Returns an API interface allowing the client application to access protected resources on behalf of a user.
        /// </summary>
        /// <param name="accessToken">The API access token.</param>
        /// <param name="secret">The access token secret.</param>
        /// <returns>A binding to the service provider's API.</returns>
		public override IGeeklist GetApi(string accessToken, string secret)
        {
			return new GeeklistTemplate(this.ConsumerKey, this.ConsumerSecret, accessToken, secret);
        }
    }
}