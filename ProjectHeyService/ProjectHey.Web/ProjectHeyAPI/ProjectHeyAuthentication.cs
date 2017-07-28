using Amazon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectHey.Web.ProjectHeyAPI
{
    public class ProjectHeyAuthentication
    {

        #region AWSSettings
        //public static string ProjectHeyAPIEndpoint = "https://qg2v8wkg9k.execute-api.eu-west-2.amazonaws.com/Prod/api";
        public static string ProjectHeyAPIEndpoint = "http://192.168.0.9:5000/api";

        public static string AWSAccessKey { get; set; }
        public static string AWSSecretKey { get; set; }

        public const string AWSIdentityPool = "eu-west-2:c3e48aac-7a76-4375-a2f9-167b72aa7867";
        public static RegionEndpoint AWSRegionEndpoint = RegionEndpoint.EUWest2;
        //public const string AWSRoleARN = "arn:aws:cognito-identity:eu-west-2:593910519982:identitypool/eu-west-2:bf2f5ee6-8025-4e5b-b818-bc941eae7a34";

        #endregion
    }

}