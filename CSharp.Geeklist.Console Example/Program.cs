using System;
using System.Diagnostics;
using CSharp.Geeklist.Api;
using CSharp.Geeklist.Connect;
using Spring.Social.OAuth1;

namespace CSharp.Geeklist.Console_Example
{
	class Program
	{
		// Register your own Geeklist app at http://hackers.geekli.st/

		// Set your consumer key & secret here
		private const string GeeklistApiKey = "ENTER YOUR KEY HERE";
		private const string GeeklistApiSecret = "ENTER YOUR SECRET HERE";

		private static void Main(string[] args)
		{
			try
			{
				var geeklistServiceProvider = new GeeklistServiceProvider(GeeklistApiKey, GeeklistApiSecret);

				/* OAuth 'dance' */

				// Authentication using Out-of-band/PIN Code Authentication
				Console.Write("Getting request token...");
				var oauthToken = geeklistServiceProvider.OAuthOperations.FetchRequestTokenAsync("oob", null).Result;
				Console.WriteLine("Done");

				var authenticateUrl = geeklistServiceProvider.OAuthOperations.BuildAuthorizeUrl(oauthToken.Value, null);
				Console.WriteLine("Redirect user for authentication: " + authenticateUrl);
				Process.Start(authenticateUrl);
				Console.WriteLine("Enter PIN Code from Geeklist authorization page:");
				var pinCode = Console.ReadLine();

				Console.Write("Getting access token...");
				var requestToken = new AuthorizedRequestToken(oauthToken, pinCode);
				var oauthAccessToken = geeklistServiceProvider.OAuthOperations.ExchangeForAccessTokenAsync(requestToken, null).Result;
				Console.WriteLine("Done");

				/* API */

				var geeklist = geeklistServiceProvider.GetApi(oauthAccessToken.Value, oauthAccessToken.Secret);

				geeklist.UserOperations.GetUserAsync()
					.ContinueWith(task => Console.WriteLine("Username: " + task.Result.User.Name));

				geeklist.ActivityOperations.GetUserActivitiesAsync()
					.ContinueWith(task => Console.WriteLine("Activities: " + task.Result.Activities.Count));

				geeklist.CardOperations.GetUserCardsAsync()
					.ContinueWith(task => Console.WriteLine("Cards: " + task.Result.CardDetails.TotalCards));

				geeklist.FollowerOperations.GetUserFollowersAsync()
					.ContinueWith(task => Console.WriteLine("Followers: " + task.Result.FollowersDetails.TotalFollowers));

				geeklist.FollowingOperations.GetUserFollowingAsync()
					.ContinueWith(task => Console.WriteLine("Following: " + task.Result.FollowingDetails.TotalFollowing));

				geeklist.MicroOperations.GetUserMicrosAsync()
					.ContinueWith(task => Console.WriteLine("Micros: " + task.Result.MicrosDetails.TotalMicros));
			}
			catch (AggregateException ae)
			{
				ae.Handle(ex =>
				{
				    if (ex is GeeklistApiException)
				    {
				        Console.WriteLine(ex.Message);
				        return true;
				    }
				    return false;
				});
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
			finally
			{
				Console.WriteLine("--- hit <return> to quit ---");
				Console.ReadLine();
			}
		}
	}
}