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
using System.IO;
using System.Collections.Generic;
using Spring.Rest.Client;
using Spring.Http;
using System.Threading.Tasks;

namespace Spring.Social.Geeklist.Api
{
	/// <summary>
	/// Interface defining the operations for Geeklist highfives.
	/// </summary>
	/// <author>Scott Smith</author>
	public interface IHighfiveOperations
	{
		/// <summary>
		/// Highfives the specified card or micro
		/// </summary>
		/// <param name="type">The type of item to highfive. Can be card or micro.</param>
		/// <param name="gfkId">The id of the item to be highfived.</param>
		/// <exception cref="GeekListApiException">If there is an error while communicating with Geeklist.</exception>
		/// <exception cref="GeekListApiException">If OAuth credentials was not provided.</exception>
		HttpResponseMessage Highfive(string type, string gfkId);

		/// <summary>
		/// Asynchronously highfives the specified card or micro
		/// </summary>
		/// <param name="type">The type of item to highfive. Can be card or micro.</param>
		/// <param name="gfkId">The id of the item to be highfived.</param>
		/// <exception cref="GeekListApiException">If there is an error while communicating with Geeklist.</exception>
		/// <exception cref="GeekListApiException">If OAuth credentials was not provided.</exception>
		Task<HttpResponseMessage> HighfiveAsync(string type, string gfkId);
	}
}