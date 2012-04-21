using System.Web.Mvc;
using CSharp.Geeklist.Api.Interfaces;
using CSharp.Geeklist.Connect;
using Spring.Social.OAuth1;


namespace CSharp.Geeklist.MVC_3_Example.Controllers
{
    public class GeeklistController : Controller
    {
		// Register your own Geeklist app at http://hackers.geekli.st/

		// Configure the Callback URL
		private const string CallbackUrl = "http://localhost:31201/Geeklist/Callback";

		// Set your consumer key & secret here
		private const string GeeklistApiKey = "ENTER YOUR KEY HERE";
		private const string GeeklistApiSecret = "ENTER YOUR SECRET HERE";

		readonly IOAuth1ServiceProvider<IGeeklist> _geeklistProvider = new GeeklistServiceProvider(GeeklistApiKey, GeeklistApiSecret);

		public ActionResult Index()
		{
			var token = Session["AccessToken"] as OAuthToken;
			if (token != null)
			{
				var geeklistClient = _geeklistProvider.GetApi(token.Value, token.Secret);

				//Uncomment the following API calls to try out different areas

				//User operation
				var user = geeklistClient.UserOperations.GetUserAsync().Result;
				//user = geeklistClient.UserOperations.GetUser();
				//user = geeklistClient.UserOperations.GetUserAsync("scottksmith95").Result;
				//user = geeklistClient.UserOperations.GetUser("kjnilsson");

				//Card operations
				//var cards = geeklistClient.CardOperations.GetUserCardsAsync().Result;
				//cards = geeklistClient.CardOperations.GetUserCards();
				//cards = geeklistClient.CardOperations.GetUserCardsAsync("scottksmith95").Result;
				//cards = geeklistClient.CardOperations.GetUserCards("shl");
				//cards = geeklistClient.CardOperations.GetUserCardsAsync(1, 50).Result;
				//cards = geeklistClient.CardOperations.GetUserCards(1, 50);
				//cards = geeklistClient.CardOperations.GetUserCardsAsync("scottksmith95", 1, 50).Result;
				//cards = geeklistClient.CardOperations.GetUserCards("shl", 1, 50);
				//var card = geeklistClient.CardOperations.GetCardAsync("95e4c5db9a3c0e15749bf1defd76f689d777cfe56741a0bb8e6be942a9062e2e").Result;
				//card = geeklistClient.CardOperations.GetCard("119e9c77bb4ae22813bfbd97349028a91b7a1913e29edab2412bd8dd8c33fd06");
				//var newCard = geeklistClient.CardOperations.CreateCardAsync("My new card via the API").Result;
				//newCard = geeklistClient.CardOperations.CreateCard("My new card via the API part 2");

				//Follower operations
				//var followers = geeklistClient.FollowerOperations.GetUserFollowersAsync().Result;
				//followers = geeklistClient.FollowerOperations.GetUserFollowers();
				//followers = geeklistClient.FollowerOperations.GetUserFollowersAsync("kjnilsson").Result;
				//followers = geeklistClient.FollowerOperations.GetUserFollowers("shl");
				//followers = geeklistClient.FollowerOperations.GetUserFollowersAsync(1, 50).Result;
				//followers = geeklistClient.FollowerOperations.GetUserFollowers(1, 50);
				//followers = geeklistClient.FollowerOperations.GetUserFollowersAsync("kcorwin", 1, 50).Result;
				//followers = geeklistClient.FollowerOperations.GetUserFollowers("shl", 1, 50);
				//var followerMessage = geeklistClient.FollowerOperations.StartFollowingAsync("eae07cd5a5ae4ab5892fa9e4514704d831df4250a7992f28b1aaaa86d1eeb28a").Result; //kjnilsson
				//followerMessage = geeklistClient.FollowerOperations.StopFollowingAsync("eae07cd5a5ae4ab5892fa9e4514704d831df4250a7992f28b1aaaa86d1eeb28a").Result;
				//followerMessage = geeklistClient.FollowerOperations.StartFollowing("eae07cd5a5ae4ab5892fa9e4514704d831df4250a7992f28b1aaaa86d1eeb28a");
				//followerMessage = geeklistClient.FollowerOperations.StopFollowing("eae07cd5a5ae4ab5892fa9e4514704d831df4250a7992f28b1aaaa86d1eeb28a");

				//Following operations
				//var following = geeklistClient.FollowingOperations.GetUserFollowingAsync().Result;
				//following = geeklistClient.FollowingOperations.GetUserFollowing();
				//following = geeklistClient.FollowingOperations.GetUserFollowingAsync("creationix").Result;
				//following = geeklistClient.FollowingOperations.GetUserFollowing("shl");
				//following = geeklistClient.FollowingOperations.GetUserFollowingAsync(1, 50).Result;
				//following = geeklistClient.FollowingOperations.GetUserFollowing(1, 50);
				//following = geeklistClient.FollowingOperations.GetUserFollowingAsync("kcorwin", 1, 50).Result;
				//following = geeklistClient.FollowingOperations.GetUserFollowing("shl", 1, 50);

				//Activity operations
				//var activites = geeklistClient.ActivityOperations.GetUserActivitiesAsync().Result;
				//activites = geeklistClient.ActivityOperations.GetUserActivities();
				//activites = geeklistClient.ActivityOperations.GetUserActivitiesAsync("creationix").Result;
				//activites = geeklistClient.ActivityOperations.GetUserActivities("shl");
				//activites = geeklistClient.ActivityOperations.GetUserActivitiesAsync(1, 50).Result;
				//activites = geeklistClient.ActivityOperations.GetUserActivities(1, 50);
				//activites = geeklistClient.ActivityOperations.GetUserActivitiesAsync("kcorwin", 1, 50).Result;
				//activites = geeklistClient.ActivityOperations.GetUserActivities("shl", 1, 50);
				//activites = geeklistClient.ActivityOperations.GetAllActivitiesAsync().Result;
				//activites = geeklistClient.ActivityOperations.GetAllActivities();
				//activites = geeklistClient.ActivityOperations.GetAllActivitiesAsync(1, 50).Result;
				//activites = geeklistClient.ActivityOperations.GetAllActivities(1, 50);
				//activites = geeklistClient.ActivityOperations.GetUserActivitiesAsync(ActivityType.Micro).Result;
				//activites = geeklistClient.ActivityOperations.GetUserActivities(ActivityType.Micro);
				//activites = geeklistClient.ActivityOperations.GetUserActivitiesAsync("creationix", ActivityType.Micro).Result;
				//activites = geeklistClient.ActivityOperations.GetUserActivities("shl", ActivityType.Micro);
				//activites = geeklistClient.ActivityOperations.GetUserActivitiesAsync(1, 50, ActivityType.Micro).Result;
				//activites = geeklistClient.ActivityOperations.GetUserActivities(1, 50, ActivityType.Micro);
				//activites = geeklistClient.ActivityOperations.GetUserActivitiesAsync("kcorwin", 1, 50, ActivityType.Micro).Result;
				//activites = geeklistClient.ActivityOperations.GetUserActivities("shl", 1, 50, ActivityType.Micro);
				//activites = geeklistClient.ActivityOperations.GetAllActivitiesAsync(ActivityType.Micro).Result;
				//activites = geeklistClient.ActivityOperations.GetAllActivities(ActivityType.Micro);
				//activites = geeklistClient.ActivityOperations.GetAllActivitiesAsync(1, 50, ActivityType.Micro).Result;
				//activites = geeklistClient.ActivityOperations.GetAllActivities(1, 50, ActivityType.Card);
				//activites = geeklistClient.ActivityOperations.GetAllActivities(1, 50, ActivityType.Contributor);
				//activites = geeklistClient.ActivityOperations.GetAllActivities(1, 50, ActivityType.Follow);
				//activites = geeklistClient.ActivityOperations.GetAllActivities(1, 50, ActivityType.Highfive);
				//activites = geeklistClient.ActivityOperations.GetAllActivities(1, 50, ActivityType.Micro);
				//activites = geeklistClient.ActivityOperations.GetAllActivities(1, 50, ActivityType.Profile);
				//activites = geeklistClient.ActivityOperations.GetAllActivities(1, 50, ActivityType.Repo);
				//activites = geeklistClient.ActivityOperations.GetAllActivities(1, 50, ActivityType.Signup);

				//Micro operations
				//var micros = geeklistClient.MicroOperations.GetUserMicrosAsync().Result;
				//micros = geeklistClient.MicroOperations.GetUserMicros();
				//micros = geeklistClient.MicroOperations.GetUserMicrosAsync("chapel").Result;
				//micros = geeklistClient.MicroOperations.GetUserMicros("chapel");
				//micros = geeklistClient.MicroOperations.GetUserMicrosAsync(1, 50).Result;
				//micros = geeklistClient.MicroOperations.GetUserMicros(1, 50);
				//micros = geeklistClient.MicroOperations.GetUserMicrosAsync("chapel", 1, 50).Result;
				//micros = geeklistClient.MicroOperations.GetUserMicros("chapel", 1, 50);
				//var micro = geeklistClient.MicroOperations.GetMicroAsync("c1e092e02938ad2a336d51ffed9d3244a8dceb80b9a00b26257549b6943c417d").Result;
				//micro = geeklistClient.MicroOperations.GetMicro("c1e092e02938ad2a336d51ffed9d3244a8dceb80b9a00b26257549b6943c417d");
				//var newMicro = geeklistClient.MicroOperations.CreateMicroAsync("My new micro via the API").Result;
				//newMicro = geeklistClient.MicroOperations.CreateMicro("My new micro via the API part 2");
				//newMicro = geeklistClient.MicroOperations.CreateMicroAsync("My new micro via the API part 4", "micro", "c1e092e02938ad2a336d51ffed9d3244a8dceb80b9a00b26257549b6943c417d").Result;
				//newMicro = geeklistClient.MicroOperations.CreateMicro("My new micro via the API part 3", "micro", "c1e092e02938ad2a336d51ffed9d3244a8dceb80b9a00b26257549b6943c417d");

				//Highfive operations
				//var highfiveMessage = geeklistClient.HighfiveOperations.HighfiveAsync(HighfiveType.Card, "95e4c5db9a3c0e15749bf1defd76f689d777cfe56741a0bb8e6be942a9062e2e").Result;
				//highfiveMessage = geeklistClient.HighfiveOperations.HighfiveAsync(HighfiveType.Micro, "c1e092e02938ad2a336d51ffed9d3244a8dceb80b9a00b26257549b6943c417d").Result;
				//highfiveMessage = geeklistClient.HighfiveOperations.Highfive(HighfiveType.Card, "119e9c77bb4ae22813bfbd97349028a91b7a1913e29edab2412bd8dd8c33fd06");
				//highfiveMessage = geeklistClient.HighfiveOperations.Highfive(HighfiveType.Micro, "6d1f1e2cf77f46c3afdacfcfe0369beedfa4ff1762e92beaee3d39dae25890a3");

				return View(user);
			}

			var requestToken = _geeklistProvider.OAuthOperations.FetchRequestTokenAsync(CallbackUrl, null).Result;

			Session["RequestToken"] = requestToken;

			return Redirect(_geeklistProvider.OAuthOperations.BuildAuthenticateUrl(requestToken.Value, null));
		}

		[HttpPost]
		public ActionResult Index(string headline)
		{
			var token = Session["AccessToken"] as OAuthToken;

			if (token != null)
			{
				var geeklistClient = _geeklistProvider.GetApi(token.Value, token.Secret);

				geeklistClient.CardOperations.CreateCard(headline);
			}

			return RedirectToAction("Index");
		}

		public ActionResult Callback(string oauth_verifier)
		{
			var requestToken = Session["RequestToken"] as OAuthToken;
			var authorizedRequestToken = new AuthorizedRequestToken(requestToken, oauth_verifier);
			var token = _geeklistProvider.OAuthOperations.ExchangeForAccessTokenAsync(authorizedRequestToken, null).Result;

			Session["AccessToken"] = token;

			return RedirectToAction("Index");
		}
    }
}
