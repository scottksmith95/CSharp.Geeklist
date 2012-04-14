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
using System.Collections.Generic;
using CSharp.Geeklist.Api.Impl.Json;
using CSharp.Geeklist.Api.Interfaces;
using CSharp.Geeklist.Api.Models;
using Spring.Json;
using Spring.Rest.Client;
using Spring.Social.OAuth1;
using Spring.Http.Converters;
using Spring.Http.Converters.Json;

namespace CSharp.Geeklist.Api.Impl
{
    /// <summary>
    /// This is the central class for interacting with Geeklist.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Most (not all) Geeklist operations require OAuth authentication. 
    /// To perform such operations, <see cref="GeeklistTemplate"/> must be constructed 
    /// with the minimal amount of information required to sign requests to Geeklist's API 
    /// with an OAuth <code>Authorization</code> header.
    /// </para>
    /// <para>
    /// There are some operations that do not require OAuth authentication. 
    /// In those cases, you may use a <see cref="GeeklistTemplate"/> that is created through 
    /// the default constructor and without any OAuth details.
    /// Attempts to perform secured operations through such an instance, however, 
    /// will result in <see cref="GeeklistApiException"/> being thrown.
    /// </para>
    /// </remarks>
    /// <author>Scott Smith</author>
    public sealed class GeeklistTemplate : AbstractOAuth1ApiBinding, IGeeklist 
    {
		private static readonly Uri ApiUriBase = new Uri("http://api.geekli.st/v1/");

        private IUserOperations _userOperations;
		private ICardOperations _cardOperations;
		private IMicroOperations _microOperations;
		private IFollowerOperations _followerOperations;
		private IFollowingOperations _followingOperations;
		private IActivityOperations _activityOperations;
		private IHighfiveOperations _highfiveOperations;

        /// <summary>
        /// Create a new instance of <see cref="GeeklistTemplate"/> able to perform unauthenticated operations against Geeklist's API.
        /// </summary>
        /// <remarks>
        /// Some operations do not require OAuth authentication. 
        /// A GeeklistTemplate created with this constructor will support those operations. 
        /// Any operations requiring authentication will throw an <see cref="GeeklistApiException"/>.
        /// </remarks>
	    public GeeklistTemplate() 
            : base()
        {
            InitSubApis();
	    }

        /// <summary>
        /// Create a new instance of <see cref="GeeklistTemplate"/>.
        /// </summary>
        /// <param name="consumerKey">The application's API key.</param>
        /// <param name="consumerSecret">The application's API secret.</param>
        /// <param name="accessToken">An access token acquired through OAuth authentication with Geeklist.</param>
        /// <param name="accessTokenSecret">An access token secret acquired through OAuth authentication with Geeklist.</param>
        public GeeklistTemplate(string consumerKey, string consumerSecret, string accessToken, string accessTokenSecret) 
            : base(consumerKey, consumerSecret, accessToken, accessTokenSecret)
        {
            InitSubApis();
	    }

        #region IGeeklist Members

        /// <summary>
        /// Gets the portion of the Geeklist API containing the user operations.
        /// </summary>
        public IUserOperations UserOperations
        {
            get { return _userOperations; }
        }

		/// <summary>
		/// Gets the portion of the Geeklist API containing the card operations.
		/// </summary>
		public ICardOperations CardOperations
		{
			get { return _cardOperations; }
		}

		/// <summary>
		/// Gets the portion of the Geeklist API containing the micro operations.
		/// </summary>
		public IMicroOperations MicroOperations
		{
			get { return _microOperations; }
		}

		/// <summary>
		/// Gets the portion of the Geeklist API containing the follower operations.
		/// </summary>
		public IFollowerOperations FollowerOperations
		{
			get { return _followerOperations; }
		}

		/// <summary>
		/// Gets the portion of the Geeklist API containing the following operations.
		/// </summary>
		public IFollowingOperations FollowingOperations
		{
			get { return _followingOperations; }
		}

		/// <summary>
		/// Gets the portion of the Geeklist API containing the activity operations.
		/// </summary>
		public IActivityOperations ActivityOperations
		{
			get { return _activityOperations; }
		}

		/// <summary>
		/// Gets the portion of the Geeklist API containing the highfive operations.
		/// </summary>
		public IHighfiveOperations HighfiveOperations
		{
			get { return _highfiveOperations; }
		}

        /// <summary>
        /// Gets the underlying <see cref="IRestOperations"/> object allowing for consumption of Geeklist endpoints 
        /// that may not be otherwise covered by the API binding. 
        /// </summary>
        /// <remarks>
        /// The <see cref="IRestOperations"/> object returned is configured to include an OAuth "Authorization" header on all requests.
        /// </remarks>
        public IRestOperations RestOperations
        {
            get { return RestTemplate; }
        }

        #endregion

        /// <summary>
        /// Enables customization of the <see cref="RestTemplate"/> used to consume provider API resources.
        /// </summary>
        /// <remarks>
        /// An example use case might be to configure a custom error handler. 
        /// Note that this method is called after the RestTemplate has been configured with the message converters returned from GetMessageConverters().
        /// </remarks>
        /// <param name="restTemplate">The RestTemplate to configure.</param>
        protected override void ConfigureRestTemplate(RestTemplate restTemplate)
        {
            restTemplate.BaseAddress = ApiUriBase;
            restTemplate.ErrorHandler = new GeeklistErrorHandler();
        }

        /// <summary>
        /// Returns a list of <see cref="IHttpMessageConverter"/>s to be used by the internal <see cref="RestTemplate"/>.
        /// </summary>
        /// <remarks>
        /// This implementation adds <see cref="SpringJsonHttpMessageConverter"/> and <see cref="ByteArrayHttpMessageConverter"/> to the default list.
        /// </remarks>
        /// <returns>
        /// The list of <see cref="IHttpMessageConverter"/>s to be used by the internal <see cref="RestTemplate"/>.
        /// </returns>
        protected override IList<IHttpMessageConverter> GetMessageConverters()
        {
            IList<IHttpMessageConverter> converters = base.GetMessageConverters();
            converters.Add(new ByteArrayHttpMessageConverter());
            converters.Add(GetJsonMessageConverter());
            return converters;
        }

        /// <summary>
        /// Returns a <see cref="SpringJsonHttpMessageConverter"/> to be used by the internal <see cref="RestTemplate"/>.
        /// <para/>
        /// Override to customize the message converter (for example, to set a custom object mapper or supported media types).
        /// </summary>
        /// <returns>The configured <see cref="SpringJsonHttpMessageConverter"/>.</returns>
        private SpringJsonHttpMessageConverter GetJsonMessageConverter()
        {
            var jsonMapper = new JsonMapper();
            jsonMapper.RegisterDeserializer(typeof(User), new UserDeserializer());
			jsonMapper.RegisterDeserializer(typeof(Avatar), new AvatarDeserializer());
			jsonMapper.RegisterDeserializer(typeof(Company), new CompanyDeserializer());
			jsonMapper.RegisterDeserializer(typeof(Social), new SocialDeserializer());
			jsonMapper.RegisterDeserializer(typeof(Criteria), new CriteriaDeserializer());
			jsonMapper.RegisterDeserializer(typeof(UserStats), new UserStatsDeserializer());
			jsonMapper.RegisterDeserializer(typeof(CardContainer), new CardContainerDeserializer());
			jsonMapper.RegisterDeserializer(typeof(IList<Card>), new CardListDeserializer());
			jsonMapper.RegisterDeserializer(typeof(Card), new CardDeserializer());
			jsonMapper.RegisterDeserializer(typeof(CardStats), new CardStatsDeserializer());
			jsonMapper.RegisterDeserializer(typeof(ShortCode), new ShortCodeDeserializer());
			jsonMapper.RegisterDeserializer(typeof(MicroContainer), new MicroContainerDeserializer());
			jsonMapper.RegisterDeserializer(typeof(IList<Micro>), new MicroListDeserializer());
			jsonMapper.RegisterDeserializer(typeof(Micro), new MicroDeserializer());
			jsonMapper.RegisterDeserializer(typeof(Reply), new ReplyDeserializer());
			jsonMapper.RegisterDeserializer(typeof(Thread), new ThreadDeserializer());
			jsonMapper.RegisterDeserializer(typeof(InReplyTo), new InReplyToDeserializer());
			jsonMapper.RegisterDeserializer(typeof(FollowerContainer), new FollowerContainerDeserializer());
			jsonMapper.RegisterDeserializer(typeof(FollowingContainer), new FollowingContainerDeserializer());
			jsonMapper.RegisterDeserializer(typeof(IList<Activity>), new ActivityListDeserializer());
			jsonMapper.RegisterDeserializer(typeof(Activity), new ActivityDeserializer());
			jsonMapper.RegisterDeserializer(typeof(Gfk), new GfkDeserializer());

            return new SpringJsonHttpMessageConverter(jsonMapper);
        }

        private void InitSubApis()
        {
            _userOperations = new UserTemplate(RestTemplate, IsAuthorized);
			_cardOperations = new CardTemplate(RestTemplate, IsAuthorized);
			_microOperations = new MicroTemplate(RestTemplate, IsAuthorized);
			_followerOperations = new FollowerTemplate(RestTemplate, IsAuthorized);
			_followingOperations = new FollowingTemplate(RestTemplate, IsAuthorized);
			_activityOperations = new ActivityTemplate(RestTemplate, IsAuthorized);
			_highfiveOperations = new HighfiveTemplate(RestTemplate, IsAuthorized);
        }
    }
}