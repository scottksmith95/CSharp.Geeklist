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

using System.Collections.Specialized;
using CSharp.Geeklist.Api.Interfaces;
using Spring.Http;
using Spring.Rest.Client;
using System.Threading.Tasks;

namespace CSharp.Geeklist.Api.Impl
{
	/// <summary>
	/// Implementation of <see cref="IHighfiveOperations"/>, providing binding to Geeklists' highfive-oriented REST resources.
	/// </summary>
	/// <author>Scott Smith</author>
	class HighfiveTemplate : AbstractGeeklistOperations, IHighfiveOperations
	{
		private readonly RestTemplate _restTemplate;

		public HighfiveTemplate(RestTemplate restTemplate, bool isAuthorized)
			: base(isAuthorized)
		{
			_restTemplate = restTemplate;
		}

		#region IHighfiveOperations Members

		public HttpResponseMessage Highfive(string type, string gfkId)
		{
			EnsureIsAuthorized();
			var request = new NameValueCollection {{"type", type}, {"gfk", gfkId}};
			return _restTemplate.PostForMessage("highfive", request);
		}

		public Task<HttpResponseMessage> HighfiveAsync(string type, string gfkId)
		{
			EnsureIsAuthorized();
			var request = new NameValueCollection {{"type", type}, {"gfk", gfkId}};
			return _restTemplate.PostForMessageAsync("highfive", request);
		}

		#endregion

		#region Private Methods



		#endregion
	}
}