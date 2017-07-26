using Newtonsoft.Json;
using ProjectHeyMobile.Authentication;
using ProjectHeyMobile.Views.Utilitypages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectHeyMobile.Views.Rootpages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        //private FacebookViewModel FacebookViewModel
        //{
        //    get { return (BindingContext as FacebookViewModel); }
        //    set { BindingContext = value; }
        //}

        public LoginPage()
        {
            InitializeComponent();
            //FacebookViewModel = new FacebookViewModel();

            BindingContext = this;

            var apiRequest =
                ProjectHeyAuthentication.AuthorizationEndpoint +
                "?client_id=" + ProjectHeyAuthentication.ClientId +
                "&display=popup&response_type=token&auth_type=rerequest" +
                "&scope=" + ProjectHeyAuthentication.Scope +
                "&redirect_uri=" + ProjectHeyAuthentication.RedirectionEndpointHTTPS;

            WebView webView = new WebView
            {
                Source = apiRequest,
                HeightRequest = 1
            };

            webView.Navigated += WebViewOnNavigated;
            Content = webView;
        }

        private async void WebViewOnNavigated(object sender, WebNavigatedEventArgs e)
        {
            try
            {
                if (e.Url.Contains("error=access_denied"))
                {
                    string cancelMessage = "Authentication Failed: user cancelled";
                    Label errorlabel = new Label()
                    {
                        HorizontalOptions = new LayoutOptions(LayoutAlignment.Center, true),
                        VerticalOptions = new LayoutOptions(LayoutAlignment.Center, true),
                        Text = cancelMessage
                    };
                    Content = errorlabel;
                    Exception userCancelledException = new Exception(cancelMessage);
                    await App.Current.MainPage.Navigation.PushAsync(new ErrorPage(userCancelledException));
                }
                else
                {
                    string token = ExtractAccessTokenFromUrl(e.Url);
                    if (!string.IsNullOrWhiteSpace(token))
                    {
                        await App.Current.MainPage.Navigation.PushAsync(new LoadingPage());
                        FacebookServices facebookServices = new FacebookServices();
                        FacebookModel facebookModel = await facebookServices.GetFacebookProfileAsync(token);
                        FacebookPermissions facebookPermissions = await facebookServices.GetPermissions(facebookModel, token);

                        List<FacebookPermission> ungrantedPermissions = new List<FacebookPermission>();
                        foreach (FacebookPermission permission in facebookPermissions.Permissions)
                        {
                            if (permission.Status.ToLower() != "granted")
                            {
                                ungrantedPermissions.Add(permission);
                            }
                        }

                        if (ungrantedPermissions.Count == 0)
                        {
                            ProjectHeyAuthentication.FacebookToken = token;
                            await App.Main.LoadUser(facebookModel);
                            if (App.Main.User != null)
                            {
                                //await App.ChatServices.ConnectHeyUser(App.Main.User.Id);
                                //GET CREDENTIALS
                                //CognitoAWSCredentials credentials
                                //    = new CognitoAWSCredentials(ProjectHeyAuthentication.AWSIdentityPool, ProjectHeyAuthentication.AWSRegionEndpoint);

                                //credentials.AddLogin("graph.facebook.com", accessToken);

                                //credentials.ClearCredentials();
                                //ImmutableCredentials ic = credentials.GetCredentials();

                                //ProjectHeyAuthentication.AWSAccessKey = ic.AccessKey;
                                //ProjectHeyAuthentication.AWSSecretKey = ic.SecretKey;
                                await App.Current.MainPage.Navigation.PopToRootAsync(false);
                            }
                            else
                            {
                                string userNotLoadedMessage = "User couldn't be loaded...";
                                Exception userNotLoadedException = new Exception(userNotLoadedMessage);
                                await App.Current.MainPage.Navigation.PushAsync(new ErrorPage(userNotLoadedException));
                            }
                        }
                        else
                        {
                            string ungrantedMessage = "Authentication Failed: access revoked by user";
                            ungrantedMessage += Environment.NewLine;
                            ungrantedMessage += "In order to use this apps, the following permissions are required:";
                            ungrantedMessage += Environment.NewLine;

                            foreach (FacebookPermission ungrantedpermission in ungrantedPermissions)
                            {
                                ungrantedMessage += ungrantedpermission.Permission + Environment.NewLine;
                            }
                            await App.Current.MainPage.Navigation.PopToRootAsync(false);
                            Exception ungrantedPermissionException = new Exception(ungrantedMessage);
                            await App.Current.MainPage.Navigation.PushAsync(new ErrorPage(ungrantedPermissionException));
                        }
                    }
                }               
            }
            catch (Exception exception)
            {
                App.Current.MainPage = new NavigationPage(new ErrorPage(exception));
            }
        }

        private string ExtractAccessTokenFromUrl(string url)
        {
            if (url.Contains("access_token") && url.Contains("&expires_in="))
            {
                string redirectwithaccess = ProjectHeyAuthentication.RedirectionEndpointHTTPS + "#access_token=";
                string redirectwithaccessonwindows = ProjectHeyAuthentication.RedirectionEndpointHTTP + "#access_token=";
                var at = url.Replace(redirectwithaccess, "");

                if (Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.WinPhone
                    || Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.WinRT
                    || Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.UWP)
                {
                    at = url.Replace(redirectwithaccessonwindows, "");
                }

                var accessToken = at.Remove(at.IndexOf("&expires_in="));

                return accessToken;
            }

            return string.Empty;
        }
    }
}