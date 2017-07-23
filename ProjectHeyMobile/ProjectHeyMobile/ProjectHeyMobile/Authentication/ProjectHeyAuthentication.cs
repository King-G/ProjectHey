
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

        public static bool IsLoggedIn
        {
            get
            {
                return !string.IsNullOrWhiteSpace(FacebookToken);
            }
        }

        #region AWSSettings

        public static string AWSAccessKey { get; set; }
        public static string AWSSecretKey { get; set; }

        public const string AWSIdentityPool = "eu-west-2:c3e48aac-7a76-4375-a2f9-167b72aa7867";
        public static RegionEndpoint AWSRegionEndpoint = RegionEndpoint.EUWest2;
        //public const string AWSRoleARN = "arn:aws:cognito-identity:eu-west-2:593910519982:identitypool/eu-west-2:bf2f5ee6-8025-4e5b-b818-bc941eae7a34";

        #endregion

        #region OAuthorization
        public const string ServiceId = "Hey.";
        public const string Scope = "public_profile, user_friends, email, user_about_me, user_actions.books, user_actions.news, user_relationships, user_birthday, user_events, user_games_activity, user_status, user_relationship_details, user_hometown, user_likes, user_actions.music, user_religion_politics, user_location, user_actions.video, user_education_history";
        public static string FacebookToken { get; set; }
        public static OAuth2Authenticator Authenticator { get; set; }
        #endregion

        #region OAuthSettings
        public static Uri AuthorizationEndpoint = new Uri("https://m.facebook.com/dialog/oauth");
        public static Uri TokenEndpoint = new Uri("https://m.facebook.com/dialog/oauth/token");
        public static Uri RedirectionEndpoint = new Uri("http://m.facebook.com/connect/login_success.html");        
        public static Uri ApiEndpoint = new Uri("https://graph.facebook.com/v2.10/");

        public static string ClientId = "139025613314996";
        public static string ClientSecret = "e1295b0564b487e4130b9101d0018d46";
        #endregion
    }
}
