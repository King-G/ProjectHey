using System;

namespace ProjectHeyMobile.Authentication
{
    public static class ServerInfo
	{
		public static Uri AuthorizationEndpoint = new Uri("https://www.facebook.com/dialog/oauth");
		public static Uri TokenEndpoint         = new Uri("https://graph.facebook.com/oauth/access_token");
		public static Uri ApiEndpoint           = new Uri("https://projecthey.eu.auth0.com/api/v2/");
		public static Uri RedirectionEndpoint 		= new Uri("com.mutatemumdum.hey://projecthey.eu.auth0.com/android/com.mutatemundum.hey/callback");
		public static string ClientId 				= "rndp8BpjsbFoLhZPlnAQaISLG7JghqiX";
		public static string ClientSecret 			= "-AMr6sMQ83kNcha9gdrpfteFgGg976qn_y0vZPjOXR62rt_EYrPWN6HQ0MDsFY5iU";
	}
}