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
        string fb_app_id = "1889013594699403";

        protected void ButtonFacebook_Clicked(object sender, EventArgs e)
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

                                    retval_client_id = fb_app_id;
                                    return retval_client_id;
                                }
                            ).Invoke(),
                     //clientSecret: "e1295b0564b487e4130b9101d0018d46",
                     authorizeUrl:
                         new Func<Uri>
                            (
                                () =>
                                {
                                    string uri = "https://www.facebook.com/v2.9/dialog/oauth";
                                    return new Uri(uri);
                                }
                            ).Invoke(),
                     //accessTokenUrl: new Uri("https://www.googleapis.com/oauth2/v4/token"),
                     redirectUrl:
                         new Func<Uri>
                            (
                                () =>
                                {
                                    string uri =
                                            //"https://localhost/path"
                                            $"fb{fb_app_id}://authorize"
                                            ;
                                    return new Uri(uri);
                                }
                            ).Invoke(),
                     scope: "", // "basic", "email",
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