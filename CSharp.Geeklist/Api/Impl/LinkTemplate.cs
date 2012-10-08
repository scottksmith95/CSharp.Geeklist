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
using CSharp.Geeklist.Api.Models;
using Spring.Rest.Client;
using System.Threading.Tasks;

namespace CSharp.Geeklist.Api.Impl
{
    /// <summary>
    /// Implementation of <see cref="ILinkOperations"/>, providing binding to Geeklists' link-oriented REST resources.
    /// </summary>
    /// <author>Scott Smith</author>
    class LinkTemplate : AbstractGeeklistOperations, ILinkOperations
    {
        private readonly RestTemplate _restTemplate;

        public LinkTemplate(RestTemplate restTemplate, bool isAuthorized)
            : base(isAuthorized)
        {
            _restTemplate = restTemplate;
        }

        #region ILinkOperations Members

        public LinksResponse GetUserLinks()
        {
            return GetUserLinks(1, 10);
        }

        public LinksResponse GetUserLinks(int page, int count)
        {
            EnsureIsAuthorized();
            var parameters = BuildPagingParametersWithCount(page, count);
            return _restTemplate.GetForObject<LinksResponse>(BuildUrl("user/links", parameters));
        }

        public LinksResponse GetUserLinks(string screenName)
        {
            return GetUserLinks(screenName, 1, 10);
        }

        public LinksResponse GetUserLinks(string screenName, int page, int count)
        {
            var parameters = BuildPagingParametersWithCount(page, count);
            return _restTemplate.GetForObject<LinksResponse>(BuildUrl("users/" + screenName + "/links", parameters));
        }

        public LinkResponse GetLink(string cardId)
        {
            return _restTemplate.GetForObject<LinkResponse>("links/" + cardId);
        }

        public LinksResponse GetPopularLinks(string communities = null)
        {
            return GetPopularLinks(1, 10, communities);
        }

        public LinksResponse GetPopularLinks(int page, int count, string communities = null)
        {
            var parameters = BuildPagingParametersWithCount(page, count);
            if (!string.IsNullOrEmpty(communities))
                parameters.Add(new NameValueCollection { { "communities", communities } });
            return _restTemplate.GetForObject<LinksResponse>(BuildUrl("links", parameters));
        }

        public LinkResponse CreateLink(string url, string title, string category = null, string description = null, string communities = null)
        {
            EnsureIsAuthorized();
            var request = new NameValueCollection { { "url", url }, { "title", title } };
            if (!string.IsNullOrEmpty(category))
                request.Add(new NameValueCollection { { "category", category } });
            if (!string.IsNullOrEmpty(description))
                request.Add(new NameValueCollection { { "description", description } });
            if (!string.IsNullOrEmpty(communities))
                request.Add(new NameValueCollection { { "communities", communities } });
            return _restTemplate.PostForObject<LinkResponse>("links", request);
        }

        public Task<LinksResponse> GetUserLinksAsync()
        {
            return GetUserLinksAsync(1, 10);
        }

        public Task<LinksResponse> GetUserLinksAsync(int page, int count)
        {
            EnsureIsAuthorized();
            var parameters = BuildPagingParametersWithCount(page, count);
            return _restTemplate.GetForObjectAsync<LinksResponse>(BuildUrl("user/links", parameters));
        }

        public Task<LinksResponse> GetUserLinksAsync(string screenName)
        {
            return GetUserLinksAsync(screenName, 1, 10);
        }

        public Task<LinksResponse> GetUserLinksAsync(string screenName, int page, int count)
        {
            var parameters = BuildPagingParametersWithCount(page, count);
            return _restTemplate.GetForObjectAsync<LinksResponse>(BuildUrl("users/" + screenName + "/links", parameters));
        }

        public Task<LinkResponse> GetLinkAsync(string cardId)
        {
            return _restTemplate.GetForObjectAsync<LinkResponse>("links/" + cardId);
        }

        public Task<LinksResponse> GetPopularLinksAsync(string communities = null)
        {
            return GetPopularLinksAsync(1, 10, communities);
        }

        public Task<LinksResponse> GetPopularLinksAsync(int page, int count, string communities = null)
        {
            var parameters = BuildPagingParametersWithCount(page, count);
            if (!string.IsNullOrEmpty(communities))
                parameters.Add(new NameValueCollection { { "communities", communities } });
            return _restTemplate.GetForObjectAsync<LinksResponse>(BuildUrl("links", parameters));
        }

        public Task<LinkResponse> CreateLinkAsync(string url, string title, string category = null, string description = null, string communities = null)
        {
            EnsureIsAuthorized();
            var request = new NameValueCollection { { "url", url }, { "title", title } };
            if (!string.IsNullOrEmpty(category))
                request.Add(new NameValueCollection { { "category", category } });
            if (!string.IsNullOrEmpty(description))
                request.Add(new NameValueCollection { { "description", description } });
            if (!string.IsNullOrEmpty(communities))
                request.Add(new NameValueCollection { { "communities", communities } });
            return _restTemplate.PostForObjectAsync<LinkResponse>("links", request);
        }

        #endregion

        #region Private Methods



        #endregion
    }
}