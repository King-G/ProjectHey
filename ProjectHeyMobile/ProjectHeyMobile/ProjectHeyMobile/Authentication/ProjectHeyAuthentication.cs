
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
using Xamarin.Forms;

namespace ProjectHeyMobile.Authentication
{
    public class ProjectHeyAuthentication
    {
        public const string FacebookAppId = "139025613314996";

        public static bool IsAuthenticated { get; set; }

        #region AWSSettings

        public static string AWSAccessKey { get; set; }
        public static string AWSSecretKey { get; set; }

        public const string AWSIdentityPool = "eu-west-2:c3e48aac-7a76-4375-a2f9-167b72aa7867";
        public static RegionEndpoint AWSRegionEndpoint = RegionEndpoint.EUWest2;
        //public const string AWSRoleARN = "arn:aws:cognito-identity:eu-west-2:593910519982:identitypool/eu-west-2:bf2f5ee6-8025-4e5b-b818-bc941eae7a34";

        #endregion
    }
}
