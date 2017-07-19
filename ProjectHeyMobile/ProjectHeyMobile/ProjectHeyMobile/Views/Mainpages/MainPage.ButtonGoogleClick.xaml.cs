using ProjectHeyMobile.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectHeyMobile.Views.Mainpages
{
    public partial class MainPage : ContentPage
	{
        protected void ButtonGoogle_Clicked(object sender, EventArgs e)
        {
            authenticator
                 = new Xamarin.Auth.OAuth2Authenticator
                 (
                     clientId:
                         new Func<string>
                            (
                                 () =>
                                 {
                                     string retval_client_id = "oops something is wrong!";

                                     // some people are sending the same AppID for google and other providers
                                     // not sure, but google (and others) might check AppID for Native/Installed apps
                                     // Android and iOS against UserAgent in request from 
                                     // CustomTabs and SFSafariViewContorller
                                     // TODO: send deliberately wrong AppID and note behaviour for the future
                                     // fitbit does not care - server side setup is quite liberal
                                     switch (Xamarin.Forms.Device.RuntimePlatform)
                                     {
                                         case "Android":
                                             retval_client_id = "32140712977-22mibrfpujrln5d09ko0q7tv8nornnto.apps.googleusercontent.com";
                                             break;
                                         case "iOS":
                                             retval_client_id = "";
                                             break;
                                         case "Windows":
                                             retval_client_id = "";
                                             break;
                                     }
                                     return retval_client_id;
                                 }
                           ).Invoke(),
                     clientSecret: null,   // null or ""
                     authorizeUrl: new Uri("https://accounts.google.com/o/oauth2/auth"),
                     accessTokenUrl: new Uri("https://www.googleapis.com/oauth2/v4/token"),
                     redirectUrl:
                         new Func<Uri>
                            (
                                 () =>
                                 {

                                     string uri = null;

                                     // some people are sending the same AppID for google and other providers
                                     // not sure, but google (and others) might check AppID for Native/Installed apps
                                     // Android and iOS against UserAgent in request from 
                                     // CustomTabs and SFSafariViewContorller
                                     // TODO: send deliberately wrong AppID and note behaviour for the future
                                     // fitbit does not care - server side setup is quite liberal
                                     switch (Xamarin.Forms.Device.RuntimePlatform)
                                     {
                                         case "Android":
                                             uri =
                                                 "com.mutatemumdum.hey://projecthey.eu.auth0.com/android/com.mutatemundum.hey/callback"
                                                 //"com.googleusercontent.apps.1093596514437-d3rpjj7clslhdg3uv365qpodsl5tq4fn:/oauth2redirect"
                                                 ;
                                             break;
                                         case "iOS":
                                             uri =
                                                 "YOUR_BUNDLE_IDENTIFIER://projecthey.eu.auth0.com/ios/YOUR_BUNDLE_IDENTIFIER/callback" //Not until I can publish an ios.
                                                  //"com.googleusercontent.apps.1093596514437-cajdhnien8cpenof8rrdlphdrboo56jh:/oauth2redirect"
                                                 ;
                                             break;
                                         case "Windows":
                                             uri =
                                                 "com.xamarin.auth.windows:/oauth2redirect" //NO Windows application yet
                                                 //"com.googleusercontent.apps.1093596514437-cajdhnien8cpenof8rrdlphdrboo56jh:/oauth2redirect"
                                                 ;
                                             break;
                                     }

                                     return new Uri(uri);
                                 }
                             ).Invoke(),
                     scope:
                                  //"profile"
                                  "https://www.googleapis.com/auth/userinfo.profile https://www.googleapis.com/auth/userinfo.email https://www.googleapis.com/auth/plus.login"
                                  ,
                     getUsernameAsync: null,
                     isUsingNativeUI: true
                 )
                 {
                     AllowCancel = true,
                 };

            authenticator.Completed +=
                (s, ea) =>
                {
                    StringBuilder sb = new StringBuilder();

                    if (ea.Account != null && ea.Account.Properties != null)
                    {
                        sb.Append("Token = ").AppendLine($"{ea.Account.Properties["access_token"]}");
                    }
                    else
                    {
                        sb.Append("Not authenticated ").AppendLine($"Account.Properties does not exist");
                    }

                    DisplayAlert
                            (
                                "Authentication Results",
                                sb.ToString(),
                                "OK"
                            );

                    return;
                };

            authenticator.Error +=
                (s, ea) =>
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("Error = ").AppendLine($"{ea.Message}");

                    DisplayAlert
                            (
                                "Authentication Error",
                                sb.ToString(),
                                "OK"
                            );
                    return;
                };

            // after initialization (creation and event subscribing) exposing local object 
            AuthenticationState.Authenticator = authenticator;

            PresentUILoginScreen(authenticator);

            return;
        }

    }
}