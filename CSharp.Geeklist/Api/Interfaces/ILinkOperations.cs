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
using CSharp.Geeklist.Api.Models;

namespace CSharp.Geeklist.Api.Interfaces
{
    /// <summary>
    /// Interface defining the operations for Geeklist link data.
    /// </summary>
    /// <author>Scott Smith</author>
    public interface ILinkOperations
    {
        /// <summary>
        /// Retrieves the first 10 links of the authenticated user.
        /// </summary>
        /// <returns>A <see cref="LinksResponse"/> with links of the authenticated user.</returns>
        /// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
        LinksResponse GetUserLinks();

        /// <summary>
        /// Retrieves links of the authenticated user.
        /// </summary>
        /// <param name="page">The page to return.</param>
        /// <param name="count">
        /// The number of <see cref="LinkResponse"/>s per page. Should be less than or equal to 50. 
        /// (Will return at most 50 entries, even if count is greater than 50)
        /// </param>
        /// <returns>A <see cref="LinksResponse"/> with links of the authenticated user.</returns>
        /// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
        LinksResponse GetUserLinks(int page, int count);

        /// <summary>
        /// Retrieves the first 10 links of the given user.
        /// </summary>
        /// <param name="screenName">The screen name of the user whose links are being requested.</param>
        /// <returns>A <see cref="LinksResponse"/> with links of the specified user.</returns>
        /// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
        LinksResponse GetUserLinks(string screenName);

        /// <summary>
        /// Retrieves links of the given user.
        /// </summary>
        /// <param name="screenName">The screen name of the user whose links are being requested.</param>
        /// <param name="page">The page to return.</param>
        /// <param name="count">
        /// The number of <see cref="LinkResponse"/>s per page. Should be less than or equal to 50. 
        /// (Will return at most 50 entries, even if count is greater than 50)
        /// </param>
        /// <returns>A <see cref="LinksResponse"/> with links of the specified user.</returns>
        /// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
        LinksResponse GetUserLinks(string screenName, int page, int count);

        /// <summary>
        /// Retrieves the link with the given link id.
        /// </summary>
        /// <param name="linkId">The id of the link whose data is being requested.</param>
        /// <returns>A <see cref="LinkResponse"/> with the specified id.</returns>
        /// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
        LinkResponse GetLink(string linkId);

        /// <summary>
        /// Retrieves the popular links
        /// </summary>
        /// <param name="communities">The community you want to see the popular links from.</param>
        /// <returns>A <see cref="LinksResponse"/> with the popular links.</returns>
        /// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
        LinksResponse GetPopularLinks(string communities = null);

        /// <summary>
        /// Retrieves the popular links
        /// </summary>
        /// <param name="page">The page to return.</param>
        /// <param name="count">
        /// The number of <see cref="LinkResponse"/>s per page. Should be less than or equal to 50. 
        /// (Will return at most 50 entries, even if count is greater than 50)
        /// </param>
        /// <param name="communities">The community you want to see the popular links from.</param>
        /// <returns>A <see cref="LinksResponse"/> with the popular links.</returns>
        /// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
        LinksResponse GetPopularLinks(int page, int count, string communities = null);

        /// <summary>
        /// Creates a new link
        /// </summary>
        /// <param name="url">The full url for the link.</param>
        /// <param name="title">The title of the link. Max length: 200 characters.</param>
        /// <param name="category">The category to use for the link, defaults to 'My links'.</param>
        /// <param name="description">The description of the link. Max length: 256 characters.</param>
        /// <param name="communities">The communities the link is in.</param>
        /// <returns>The created <see cref="LinkResponse"/>.</returns>
        /// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
        LinkResponse CreateLink(string url, string title, string category = null, string description = null, string communities = null);

        /// <summary>
        /// Asynchronously retrieves the first 10 links of the authenticated user.
        /// </summary>
        /// <returns>A <see cref="LinksResponse"/> with links of the authenticated user.</returns>
        /// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
        Task<LinksResponse> GetUserLinksAsync();

        /// <summary>
        /// Asynchronously retrieves links of the authenticated user.
        /// </summary>
        /// <param name="page">The page to return.</param>
        /// <param name="count">
        /// The number of <see cref="LinkResponse"/>s per page. Should be less than or equal to 50. 
        /// (Will return at most 50 entries, even if count is greater than 50)
        /// </param>
        /// <returns>A <see cref="LinksResponse"/> with links of the authenticated user.</returns>
        /// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
        Task<LinksResponse> GetUserLinksAsync(int page, int count);

        /// <summary>
        /// Asynchronously retrieves the first 10 links of the given user.
        /// </summary>
        /// <param name="screenName">The screen name of the user whose links are being requested.</param>
        /// <returns>A <see cref="LinksResponse"/> with links of the specified user.</returns>
        /// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
        Task<LinksResponse> GetUserLinksAsync(string screenName);

        /// <summary>
        /// Asynchronously retrieves links of the given user.
        /// </summary>
        /// <param name="screenName">The screen name of the user whose links are being requested.</param>
        /// <param name="page">The page to return.</param>
        /// <param name="count">
        /// The number of <see cref="LinkResponse"/>s per page. Should be less than or equal to 50. 
        /// (Will return at most 50 entries, even if count is greater than 50)
        /// </param>
        /// <returns>A <see cref="LinksResponse"/> with links of the specified user.</returns>
        /// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
        Task<LinksResponse> GetUserLinksAsync(string screenName, int page, int count);

        /// <summary>
        /// Asynchronously retrieves the link with the given link id.
        /// </summary>
        /// <param name="linkId">The id of the link whose data is being requested.</param>
        /// <returns>A <see cref="LinkResponse"/> with the specified id.</returns>
        /// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
        Task<LinkResponse> GetLinkAsync(string linkId);

        /// <summary>
        /// Asynchronously retrieves the popular links
        /// </summary>
        /// <param name="communities">The community you want to see the popular links from.</param>
        /// <returns>A <see cref="LinksResponse"/> with the popular links.</returns>
        /// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
        Task<LinksResponse> GetPopularLinksAsync(string communities = null);

        /// <summary>
        /// Asynchronously retrieves the popular links
        /// </summary>
        /// <param name="page">The page to return.</param>
        /// <param name="count">
        /// The number of <see cref="LinkResponse"/>s per page. Should be less than or equal to 50. 
        /// (Will return at most 50 entries, even if count is greater than 50)
        /// </param>
        /// <param name="communities">The community you want to see the popular links from.</param>
        /// <returns>A <see cref="LinksResponse"/> with the popular links.</returns>
        /// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
        Task<LinksResponse> GetPopularLinksAsync(int page, int count, string communities = null);

        /// <summary>
        /// Asynchronously creates a new link
        /// </summary>
        /// <param name="url">The full url for the link.</param>
        /// <param name="title">The title of the link. Max length: 200 characters.</param>
        /// <param name="category">The category to use for the link, defaults to 'My links'.</param>
        /// <param name="description">The description of the link. Max length: 256 characters.</param>
        /// <param name="communities">The communities the link is in.</param>
        /// <returns>The created <see cref="LinkResponse"/>.</returns>
        /// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
        Task<LinkResponse> CreateLinkAsync(string url, string title, string category = null, string description = null, string communities = null);
    }
}
