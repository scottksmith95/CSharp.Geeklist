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
using System.Text;

using Spring.Json;
using Spring.Http;
using Spring.Rest.Client;
using Spring.Rest.Client.Support;

//TODO: Implement Geeklists errors
namespace Spring.Social.Geeklist.Api.Impl
{
    /// <summary>
    /// Implementation of the <see cref="IResponseErrorHandler"/> that handles errors from Geeklist's REST API, 
    /// interpreting them into appropriate exceptions.
    /// </summary>
    /// <author>Craig Walls</author>
    /// <author>Bruno Baia (.NET)</author>
    class GeeklistErrorHandler : DefaultResponseErrorHandler
    {
        // Default encoding for JSON
        private static readonly Encoding DEFAULT_CHARSET = new UTF8Encoding(false); // Remove byte Order Mask (BOM)

        /// <summary>
        /// Handles the error in the given response. 
        /// <para/>
        /// This method is only called when HasError() method has returned <see langword="true"/>.
        /// </summary>
        /// <remarks>
        /// This implementation throws appropriate exception if the response status code 
        /// is a client code error (4xx) or a server code error (5xx). 
        /// </remarks>
        /// <param name="requestUri">The request URI.</param>
        /// <param name="requestMethod">The request method.</param>
        /// <param name="response">The response message with the error.</param>
        public override void HandleError(Uri requestUri, HttpMethod requestMethod, HttpResponseMessage<byte[]> response)
        {
            int type = (int)response.StatusCode / 100;
            if (type == 4)
            {
                this.HandleClientErrors(response);
            }
            else if (type == 5)
            {
                this.HandleServerErrors(response.StatusCode);
            }

            // if not otherwise handled, do default handling and wrap with GeeklistApiException
            try
            {
                base.HandleError(requestUri, requestMethod, response);
            }
            catch (Exception ex)
            {
                throw new GeeklistApiException("Error consuming Geeklist REST API.", ex);
            }
        }

        private void HandleClientErrors(HttpResponseMessage<byte[]> response) 
        {
		    JsonValue errorValue = this.ExtractErrorDetailsFromResponse(response);
		    if (errorValue == null) 
            {
			    return; // unexpected error body, can't be handled here
		    }

		    string errorText = null;
		    if (errorValue.ContainsName("error")) 
            {
			    errorText = errorValue.GetValue<string>("error");
		    } 
            else if(errorValue.ContainsName("errors")) 
            {
			    JsonValue errorsValue = errorValue.GetValue("errors");			
			    if (errorsValue.IsArray) 
                {
				    errorText = errorsValue.GetValue(0).GetValue<string>("message");
			    } 
                else if (errorsValue.IsString) 
                {
				    errorText = errorsValue.GetValue<string>();
			    }
		    }

		    if (response.StatusCode == HttpStatusCode.Unauthorized) 
            {
                if (errorText == "Could not authenticate you.")
                {
                    throw new GeeklistApiException(
                        "Authorization is required for the operation, but the API binding was created without authorization.", 
                        GeeklistApiError.NotAuthorized);
			    }
                else if (errorText == "Could not authenticate with OAuth.")
                {
                    throw new GeeklistApiException("The authorization has been revoked.", GeeklistApiError.NotAuthorized);
			    }
                else 
                {
                    throw new GeeklistApiException(errorText ?? response.StatusDescription, GeeklistApiError.NotAuthorized);
			    }
		    } 
            else if (response.StatusCode == HttpStatusCode.Forbidden) 
            {
                throw new GeeklistApiException(errorText, GeeklistApiError.OperationNotPermitted);
		    } 
            else if (response.StatusCode == HttpStatusCode.NotFound) 
            {
                throw new GeeklistApiException(errorText, GeeklistApiError.ResourceNotFound);
		    }
            else if (response.StatusCode == (HttpStatusCode)420)
            {
                throw new GeeklistApiException("The rate limit has been exceeded.", GeeklistApiError.RateLimitExceeded);
            }
	    }

	    private void HandleServerErrors(HttpStatusCode statusCode)
        {
		    if (statusCode == HttpStatusCode.InternalServerError) 
            {
                throw new GeeklistApiException(
                    "Something is broken at Geeklist. Please see http://dev.twitter.com/pages/support to report the issue.", 
                    GeeklistApiError.Server);
		    } 
            else if (statusCode == HttpStatusCode.BadGateway) 
            {
                throw new GeeklistApiException("Geeklist is down or is being upgraded.", GeeklistApiError.ServerDown);
		    } 
            else if (statusCode == HttpStatusCode.ServiceUnavailable) 
            {
                throw new GeeklistApiException("Geeklist is overloaded with requests. Try again later.", GeeklistApiError.ServerOverloaded);
		    }
	    }

        private JsonValue ExtractErrorDetailsFromResponse(HttpResponseMessage<byte[]> response) 
        {
            if (response.Body == null)
            {
                return null;
            }
            MediaType contentType = response.Headers.ContentType;
            Encoding charset = (contentType != null && contentType.CharSet != null) ? contentType.CharSet : DEFAULT_CHARSET;
            string errorDetails = charset.GetString(response.Body, 0, response.Body.Length);
            
            JsonValue result;
            return JsonValue.TryParse(errorDetails, out result) ? result : null;
	    }
    }
}