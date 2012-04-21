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

using CSharp.Geeklist.Api.Interfaces;
using CSharp.Geeklist.Api.Models;
using Spring.Rest.Client;
using System.Threading.Tasks;

namespace CSharp.Geeklist.Api.Impl
{
    /// <summary>
    /// Implementation of <see cref="IUserOperations"/>, providing binding to Geeklists' user-oriented REST resources.
    /// </summary>
	/// <author>Scott Smith</author>
    class UserTemplate : AbstractGeeklistOperations, IUserOperations
    {
        private readonly RestTemplate _restTemplate;

        public UserTemplate(RestTemplate restTemplate, bool isAuthorized)
            : base(isAuthorized)
        {
            _restTemplate = restTemplate;
        }

        #region IUserOperations Members

		public UserResponse GetUser() 
        {
		    EnsureIsAuthorized();
			return _restTemplate.GetForObject<UserResponse>("user");
	    }

	    public UserResponse GetUser(string screenName) 
        {
			return _restTemplate.GetForObject<UserResponse>("users/" + screenName);
	    }

		public Task<UserResponse> GetUserAsync()
		{
			EnsureIsAuthorized();
			return _restTemplate.GetForObjectAsync<UserResponse>("user");
		}

		public Task<UserResponse> GetUserAsync(string screenName)
		{
			return _restTemplate.GetForObjectAsync<UserResponse>("users/" + screenName);
		}

        #endregion

        #region Private Methods



        #endregion
    }
}