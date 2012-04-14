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
using System.Net;
using System.Collections.Generic;
using System.Collections.Specialized;

using Spring.Http;
using Spring.Rest.Client;
using System.Threading.Tasks;

namespace Spring.Social.Geeklist.Api.Impl
{
    /// <summary>
    /// Implementation of <see cref="IUserOperations"/>, providing binding to Geeklists' user-oriented REST resources.
    /// </summary>
	/// <author>Scott Smith</author>
    class UserTemplate : AbstractGeeklistOperations, IUserOperations
    {
        private RestTemplate restTemplate;

        public UserTemplate(RestTemplate restTemplate, bool isAuthorized)
            : base(isAuthorized)
        {
            this.restTemplate = restTemplate;
        }

        #region IUserOperations Members

		public User GetUser() 
        {
		    this.EnsureIsAuthorized();
			return this.restTemplate.GetForObject<User>("v1/user");
	    }

	    public User GetUser(string screenName) 
        {
			return this.restTemplate.GetForObject<User>("v1/users/" + screenName);
	    }

		public Task<User> GetUserAsync()
		{
			this.EnsureIsAuthorized();
			return this.restTemplate.GetForObjectAsync<User>("v1/user");
		}

		public Task<User> GetUserAsync(string screenName)
		{
			return this.restTemplate.GetForObjectAsync<User>("v1/users/" + screenName);
		}

        #endregion

        #region Private Methods



        #endregion
    }
}