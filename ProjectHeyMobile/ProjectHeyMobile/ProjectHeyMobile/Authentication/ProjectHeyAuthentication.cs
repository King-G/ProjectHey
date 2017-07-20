
using Amazon;
using Amazon.CognitoIdentity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Auth;
using Xamarin.Forms;

namespace ProjectHeyMobile.Authentication
{
    public class ProjectHeyAuthentication
    {
        public const string FacebookAppId = "139025613314996";


        public static bool IsAuthenticated { get; set; }

        #region AWSSettings
        private static CognitoAWSCredentials _AWSCredentials = new CognitoAWSCredentials("eu-west-2:a2455afb-c917-464f-9c8a-e90697708a6e", RegionEndpoint.EUWest2);

        public static CognitoAWSCredentials AWSCredentials
        {
            get { return _AWSCredentials; }
            set { _AWSCredentials = value; }
        }
        #endregion

        #region OAuthorization
        public const string ServiceId = "Hey.";
        public const string Scope = "profile";
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
