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
using System.Globalization;
using Spring.Json;

namespace Spring.Social.Geeklist.Api.Impl.Json
{
	/// <summary>
	/// JSON deserializer for data for cards. 
	/// </summary>
	/// <author>Scott Smith</author>
	class CardContainerDeserializer : IJsonDeserializer
	{
		public object Deserialize(JsonValue value, JsonMapper mapper)
		{
			value = value.GetValue("data");

			return new CardContainer
			{
				TotalCards = value.GetValue<long>("total_cards"),
				Cards = mapper.Deserialize<List<Card>>(value.GetValue("cards"))
			};
		}
	}

	/// <summary>
	/// JSON deserializer for list of cards. 
	/// </summary>
	/// <author>Scott Smith</author>
	class CardListDeserializer : IJsonDeserializer
	{
		public object Deserialize(JsonValue value, JsonMapper mapper)
		{
			IList<Card> cards = new List<Card>();
			foreach (JsonValue itemValue in value.GetValues())
			{
				cards.Add(mapper.Deserialize<Card>(itemValue));
			}
			return cards;
		}
	}

	/// <summary>
	/// JSON deserializer for Geeklist card.
	/// </summary>
	/// <author>Scott Smith</author>
	class CardDeserializer : IJsonDeserializer
	{
		public object Deserialize(JsonValue value, JsonMapper mapper)
		{
			return new Card()
			{
				AuthorId = value.GetValue<string>("author_id"),
				Created = value.GetValue<DateTime>("created_at"),
				Happened = value.GetValue<DateTime>("happened_at"),
				HappenedType = value.GetValue<string>("happened_at_type"),
				Headline = value.GetValue<string>("headline"),
				IsActive = value.GetValue<bool>("is_active"),
				Permalink = value.GetValue<string>("permalink"),
				Slug = value.GetValue<string>("slug"),
				Tasks = value.GetValue<List<string>>("tasks"),
				Updated = value.GetValue<DateTime>("updated_at"),
				Stats = mapper.Deserialize<CardStats>(value.GetValue("stats")),
				ShortCode = mapper.Deserialize<ShortCode>(value.GetValue("short_code")),
				Id = value.GetValue<string>("id"),
			};
		}
	}

	/// <summary>
	/// JSON deserializer for Geeklist card stats.
	/// </summary>
	/// <author>Scott Smith</author>
	class CardStatsDeserializer : IJsonDeserializer
	{
		public object Deserialize(JsonValue value, JsonMapper mapper)
		{
			return new CardStats()
			{
				NumberOfViews = value.GetValue<long>("number_of_views"),
				Views = value.GetValue<long>("views"),
				HighFives = value.GetValue<long>("highfives"),
			};
		}
	}

	/// <summary>
	/// JSON deserializer for Geeklist card stats.
	/// </summary>
	/// <author>Scott Smith</author>
	class ShortCodeDeserializer : IJsonDeserializer
	{
		public object Deserialize(JsonValue value, JsonMapper mapper)
		{
			return new ShortCode()
			{
				GklstUrl = value.GetValue<string>("gklst_url"),
				Id = value.GetValue<string>("id"),
			};
		}
	}
}