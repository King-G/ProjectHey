using Newtonsoft.Json.Linq;
using ProjectHeyMobile.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectHeyMobile.Views.Mainpages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        const string ServiceId = "Hey.";
        const string Scope = "profile";

        Account account;
        AccountStore store = null;

        public MainPage()
        {
            InitializeComponent();


            store = AccountStore.Create();
            account = store.FindAccountsForService(ServiceId).FirstOrDefault();
            this.BindingContext = this;


            buttonGoogle.Clicked += ButtonGoogle_Clicked;
            buttonFacebook.Clicked += ButtonFacebook_Clicked;

            return;
        }

        void AuthorizationCodeButtonClicked(object sender, EventArgs e)
        {
            OAuth2Authenticator authenticator = new OAuth2Authenticator
                (
                    ServerInfo.ClientId,
                    ServerInfo.ClientSecret,
                    Scope,
                    ServerInfo.AuthorizationEndpoint,
                    ServerInfo.RedirectionEndpoint,
                    ServerInfo.TokenEndpoint,
                    null,
                    isUsingNativeUI: true
                );

            authenticator.Completed += OnAuthCompleted;
            authenticator.Error += OnAuthError;

            AuthenticationState.Authenticator = authenticator;

            PresentUILoginScreen(authenticator);

            return;
        }

        async void GetProfileButtonClicked(object sender, EventArgs e)
        {
            try
            {
                var request = new OAuth2Request("GET", ServerInfo.ApiEndpoint, null, account);
                var response = await request.GetResponseAsync();

                var text = response.GetResponseText();

                var json = JObject.Parse(text);

                var name = (string)json["Name"];
                var email = (string)json["Email"];
                var imageUrl = (string)json["ImageUrl"];

                var imageRequest = new OAuth2Request("GET", new Uri(imageUrl), null, account);
                var stream = await (await imageRequest.GetResponseAsync()).GetResponseStreamAsync();

                //profileImage.Source = ImageSource.FromStream(() => stream);

                await App.Current.MainPage.DisplayAlert("Hello there:", "Get data succeeded", "ok");
            }
            catch (Exception x)
            {
                await App.Current.MainPage.DisplayAlert("Oops", "Get data failure: " + x.Message + "\r\nHas the access token expired?", "ok");
            }
        }

        async void RefreshButtonClicked(object sender, EventArgs e)
        {
            var refreshToken = account.Properties["refresh_token"];

            if (string.IsNullOrWhiteSpace(refreshToken))
                return;

            var queryValues = new Dictionary<string, string>
            {
                {"refresh_token", refreshToken},
                {"client_id", ServerInfo.ClientId},
                {"grant_type", "refresh_token"},
                {"client_secret", ServerInfo.ClientSecret},
            };

            var authenticator = new OAuth2Authenticator
                (
                    ServerInfo.ClientId,
                    ServerInfo.ClientSecret,
                    "profile",
                    ServerInfo.AuthorizationEndpoint,
                    ServerInfo.RedirectionEndpoint,
                    ServerInfo.TokenEndpoint,
                    null,
                    isUsingNativeUI: true
                );

            try
            {
                var result = await authenticator.RequestAccessTokenAsync(queryValues);

                if (result.ContainsKey("access_token"))
                    account.Properties["access_token"] = result["access_token"];

                if (result.ContainsKey("refresh_token"))
                    account.Properties["refresh_token"] = result["refresh_token"];

                store.Save(account, ServiceId);

                await App.Current.MainPage.DisplayAlert("WoopWoop", "Refresh suceeded ", "ok");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Oops", "Refresh failed " + ex.Message, "ok");

            }
        }

        void OnAuthCompleted(object sender, AuthenticatorCompletedEventArgs e)
        {
            var authenticator = sender as OAuth2Authenticator;

            if (authenticator != null)
            {
                authenticator.Completed -= OnAuthCompleted;
                authenticator.Error -= OnAuthError;
            }

            if (e.IsAuthenticated)
            {
                if (this.account != null)
                    store.Delete(this.account, ServiceId);

                store.Save(account = e.Account, ServiceId);


                if (account.Properties.ContainsKey("expires_in"))
                {
                    var expires = int.Parse(account.Properties["expires_in"]);
                    App.Current.MainPage.DisplayAlert("WoopWoop", "Token lifetime is: " + expires + "s", "ok");
                }
                else
                {
                    App.Current.MainPage.DisplayAlert("WoopWoop", "Authentication succeeded", "ok");

                }

            }
            else
            {
                App.Current.MainPage.DisplayAlert("oops", "Authentication failed", "ok");

            }
        }

        void OnAuthError(object sender, AuthenticatorErrorEventArgs e)
        {
            var authenticator = sender as OAuth2Authenticator;

            if (authenticator != null)
            {
                authenticator.Completed -= OnAuthCompleted;
                authenticator.Error -= OnAuthError;
            }

            App.Current.MainPage.DisplayAlert("oops", "Authentication error: " + e.Message, "ok");
        }



        Xamarin.Auth.OAuth2Authenticator authenticator = null;

        private void PresentUILoginScreen(OAuth2Authenticator authenticator)
        {
            System.Diagnostics.Debug.WriteLine("Presenting");
            System.Diagnostics.Debug.WriteLine("        PushModal");
            System.Diagnostics.Debug.WriteLine("        Presenters");

            Xamarin.Auth.Presenters.OAuthLoginPresenter presenter = null;
            presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
            presenter.Login(authenticator);

            return;
        }

    }
}