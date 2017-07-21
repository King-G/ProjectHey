
using Amazon;
using Amazon.CognitoIdentity;
using Amazon.Runtime;
using ProjectHeyMobile.APICommunication;
using Refit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Auth;
using Xamarin.Forms;

namespace ProjectHeyMobile.Authentication
{
    public class ProjectHeyAuthentication
    {
        public const string FacebookAppId = "139025613314996";

        public static bool IsAuthenticated { get; set; }

        #region AWSSettings
        public static async Task<IProjectHeyAPI> GetProjectHeyAPI()
        {
            return RestService.For<IProjectHeyAPI>(new HttpClient(new AuthenticatedHttpClientHandler(await GetAWSAccessToken())) { BaseAddress = new Uri("https://qg2v8wkg9k.execute-api.eu-west-2.amazonaws.com/Prod/api") });
        }
        public static async Task<string> GetAWSAccessToken()
        {
            ImmutableCredentials ic = await AWSCredentials.GetCredentialsAsync();
            return ic.Token;
        }
        public static CognitoAWSCredentials AWSCredentials = new CognitoAWSCredentials("eu-west-2:bf2f5ee6-8025-4e5b-b818-bc941eae7a34", RegionEndpoint.EUWest2);
        #endregion

        #region OAuthorization
        public const string ServiceId = "Hey.";
        public const string Scope = "profile";
        public static string FacebookAccessToken { get; set; }
        #endregion

        #region OAuthSettings
        public static Uri AuthorizationEndpoint = new Uri("https://projecthey.eu.auth0.com/authorize");
        public static Uri TokenEndpoint = new Uri("https://projecthey.eu.auth0.com/oauth/token");
        public static Uri ApiEndpoint = new Uri("https://projecthey.eu.auth0.com/userinfo");
        public static Uri RedirectionEndpoint = new Uri("com.mutatemundum.hey://projecthey.eu.auth0.com/android/com.mutatemundum.hey/callback");

        public static string ClientId = "rndp8BpjsbFoLhZPlnAQaISLG7JghqiX";
        public static string ClientSecret = "AMr6sMQ83kNcha9gdrpfteFgGg976qn_y0vZPjOXR62rt_EYrPWN6HQ0MDsFY5iU"; 
        #endregion

    }
}
