using Amazon.CognitoIdentity;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Auth;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjectHeyMobile.Authentication;
using ProjectHeyMobile.Views.Utilitypages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectHeyMobile.Views.Rootpages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {

        private string ClientId = "139025613314996";
        private FacebookViewModel FacebookViewModel
        {
            get { return (BindingContext as FacebookViewModel); }
            set { BindingContext = value; }
        }
        public LoginPage()
        {
            InitializeComponent();
            FacebookViewModel = new FacebookViewModel();
            var apiRequest =
                "https://www.facebook.com/dialog/oauth?client_id="
                + ClientId
                + "&display=popup&response_type=token&redirect_uri=http://www.facebook.com/connect/login_success.html";

            var webView = new WebView
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
                var accessToken = ExtractAccessTokenFromUrl(e.Url);

                if (accessToken != "")
                {
                    await FacebookViewModel.SetFacebookUserProfileAsync(accessToken);

                    CognitoAWSCredentials credentials
                        = new CognitoAWSCredentials(ProjectHeyAuthentication.AWSIdentityPool, ProjectHeyAuthentication.AWSRegionEndpoint);

                    credentials.AddLogin("graph.facebook.com", accessToken);
                    var identity = credentials.GetIdentityId();

                    ImmutableCredentials ic = credentials.GetCredentials();
                    ProjectHeyAuthentication.AWSAccessKey = ic.AccessKey;
                    ProjectHeyAuthentication.AWSSecretKey = ic.SecretKey;

                    //=======
                    //S4Signing....

                    //=======
                    App.LoadUser(FacebookViewModel.FacebookModel);
                    App.Current.MainPage = new NavigationPage(new RootPage());
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
                var at = url.Replace("https://www.facebook.com/connect/login_success.html#access_token=", "");

                if (Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.WinPhone
                    || Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.WinRT
                    || Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.UWP)
                {
                    at = url.Replace("http://www.facebook.com/connect/login_success.html#access_token=", "");
                }

                var accessToken = at.Remove(at.IndexOf("&expires_in="));

                return accessToken;
            }

            return string.Empty;
        }
        //async Task<FacebookModel> GetProfile()
        //{
        //    try
        //    {
        //        #region WHILE WE WAIT FOR  AUTH0 TO GET THEIR SHIT TOGETHER
        //        FacebookModel facebookModel = new FacebookModel()
        //        {
        //            name = "Karim Gabsi",
        //            family_name = "Gabsi",
        //            given_name = "Karim",
        //            email = "gabsikarim@gmail.com",
        //            age_range = new AgeRange() { min = 21 },
        //            gender = "male",
        //            birthday = "01/16/1991",
        //            location = new Location() { id = "114521328558541", name = "Kortrijk" }

        //        };

        //        return facebookModel;
        //        #endregion


        //        //#region AUTH0 FIXED WHATEVER NEEDED FIXED
        //        //var request = new OAuth2Request("GET", ProjectHeyAuthentication.ApiEndpoint, null, account);

        //        //var response = await request.GetResponseAsync();
        //        //var responseData = await response.GetResponseTextAsync();

        //        //FacebookModel facebookModel = JsonConvert.DeserializeObject<FacebookModel>(responseData);

        //        //return facebookModel;
        //        ////var imageRequest = new OAuth2Request("GET", new Uri(imageUrl), null, account);
        //        ////var stream = await (await imageRequest.GetResponseAsync()).GetResponseStreamAsync();
        //        ////profileImage.Source = ImageSource.FromStream(() => stream);
        //        //#endregion


        //    }
        //    catch (Exception exception)
        //    {
        //        await App.Current.MainPage.DisplayAlert("Oops", "Get data failure: " + exception.Message + "\r\nHas the access token expired?", "ok");
        //        return null;
        //    }
        //}

        //#region TOKEN REFRESH
        ////async void RefreshButtonClicked(object sender, EventArgs e)
        ////{
        ////    var refreshToken = account.Properties["refresh_token"];

        ////    if (string.IsNullOrWhiteSpace(refreshToken))
        ////        return;

        ////    var queryValues = new Dictionary<string, string>
        ////    {
        ////        {"refresh_token", refreshToken},
        ////        {"client_id", ServerInfo.ClientId},
        ////        {"grant_type", "refresh_token"},
        ////        {"client_secret", ServerInfo.ClientSecret},
        ////    };

        ////    var authenticator = new OAuth2Authenticator
        ////        (
        ////            ServerInfo.ClientId,
        ////            ServerInfo.ClientSecret,
        ////            "profile",
        ////            ServerInfo.AuthorizationEndpoint,
        ////            ServerInfo.RedirectionEndpoint,
        ////            ServerInfo.TokenEndpoint,
        ////            null,
        ////            isUsingNativeUI: true
        ////        );

        ////    try
        ////    {
        ////        var result = await authenticator.RequestAccessTokenAsync(queryValues);

        ////        if (result.ContainsKey("access_token"))
        ////            account.Properties["access_token"] = result["access_token"];

        ////        if (result.ContainsKey("refresh_token"))
        ////            account.Properties["refresh_token"] = result["refresh_token"];

        ////        store.Save(account, ServiceId);

        ////        await App.Current.MainPage.DisplayAlert("WoopWoop", "Refresh suceeded ", "ok");
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        await App.Current.MainPage.DisplayAlert("Oops", "Refresh failed " + ex.Message, "ok");

        ////    }
        ////}

        //#endregion

        //async void OnAuthCompleted(object sender, AuthenticatorCompletedEventArgs e)
        //{
        //    var authenticator = sender as OAuth2Authenticator;

        //    if (authenticator != null)
        //    {
        //        authenticator.Completed -= OnAuthCompleted;
        //        authenticator.Error -= OnAuthError;
        //    }

        //    if (e.IsAuthenticated)
        //    {
        //        ProjectHeyAuthentication.IsAuthenticated = e.IsAuthenticated;

        //        if (account != null)
        //            store.Delete(account, ProjectHeyAuthentication.ServiceId);

        //        account = e.Account;
        //        store.Save(account, ProjectHeyAuthentication.ServiceId);


        //        ProjectHeyAuthentication.FacebookAccessToken = account.Properties["access_token"];


        //        //ProjectHeyAuthentication.AWSCredentials.AddLogin("projecthey.eu.auth0.com", ProjectHeyAuthentication.FacebookAccessToken);

        //        ProjectHeyAuthentication.AWSCredentials.AddLogin("graph.facebook.com", ProjectHeyAuthentication.FacebookAccessToken);

        //        try
        //        {
        //            ImmutableCredentials ic = await ProjectHeyAuthentication.AWSCredentials.GetCredentialsAsync();
        //            IDictionary<string, string> test = authenticator.RequestAccessTokenAsync(authenticator.ClientSecret).Result;

        //        }
        //        catch (Exception exception)
        //        {

        //        }

        //        buttonHey.IsEnabled = true;
        //        buttonFacebook.IsEnabled = false;
        //    }
        //    else
        //    {
        //       await App.Current.MainPage.DisplayAlert("Dammit...", "Authentication Failed", "I'll report it");

        //    }
        //}

        //void OnAuthError(object sender, AuthenticatorErrorEventArgs e)
        //{

        //    var authenticator = sender as OAuth2Authenticator;

        //    if (authenticator != null)
        //    {
        //        authenticator.Completed -= OnAuthCompleted;
        //        authenticator.Error -= OnAuthError;

        //    }

        //    App.Current.MainPage.DisplayAlert("Dammit... Obviously something went wrong...", e.Message,  "It happens...");
        //}

    }
}