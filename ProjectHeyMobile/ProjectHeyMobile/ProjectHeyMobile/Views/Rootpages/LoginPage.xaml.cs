using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjectHeyMobile.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Auth;
using Xamarin.Auth.XamarinForms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectHeyMobile.Views.Rootpages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        Account account;
        AccountStore store;
        public LoginPage()
        {
            InitializeComponent();
            store = AccountStore.Create();
            account = store.FindAccountsForService(ProjectHeyAuthentication.ServiceId).FirstOrDefault();
            this.BindingContext = this;

            buttonFacebook.Clicked += ButtonFacebook_Clicked;
            ButtonFacebook_Clicked(this, new EventArgs());
        }

        void ButtonFacebook_Clicked(object sender, EventArgs e)
        {
            OAuth2Authenticator authenticator = new OAuth2Authenticator
                (
                    ProjectHeyAuthentication.ClientId,
                    ProjectHeyAuthentication.ClientSecret,
                    ProjectHeyAuthentication.Scope,
                    ProjectHeyAuthentication.AuthorizationEndpoint,
                    ProjectHeyAuthentication.RedirectionEndpoint,
                    ProjectHeyAuthentication.TokenEndpoint,
                    getUsernameAsync: null,
                    isUsingNativeUI: true
                );

            authenticator.Completed += OnAuthCompleted;
            authenticator.Error += OnAuthError;

            AuthenticationState.Authenticator = authenticator;

            PresentUILoginScreen(authenticator);

        }

        async void SyncProfile()
        {
            try
            {
                var request = new OAuth2Request("GET", ProjectHeyAuthentication.ApiEndpoint, null, account);
                var response = await request.GetResponseAsync();
                var responseData = response.GetResponseText();

                FacebookModel facebookModel = JsonConvert.DeserializeObject<FacebookModel>(responseData);

                //var imageRequest = new OAuth2Request("GET", new Uri(imageUrl), null, account);
                //var stream = await (await imageRequest.GetResponseAsync()).GetResponseStreamAsync();
                //profileImage.Source = ImageSource.FromStream(() => stream);

                App.LoadUser(facebookModel);
                App.Current.MainPage = new NavigationPage(new RootPage());
            }
            catch (Exception exception)
            {
                await App.Current.MainPage.DisplayAlert("Oops", "Get data failure: " + exception.Message + "\r\nHas the access token expired?", "ok");
            }
        }

        //async void RefreshButtonClicked(object sender, EventArgs e)
        //{
        //    var refreshToken = account.Properties["refresh_token"];

        //    if (string.IsNullOrWhiteSpace(refreshToken))
        //        return;

        //    var queryValues = new Dictionary<string, string>
        //    {
        //        {"refresh_token", refreshToken},
        //        {"client_id", ServerInfo.ClientId},
        //        {"grant_type", "refresh_token"},
        //        {"client_secret", ServerInfo.ClientSecret},
        //    };

        //    var authenticator = new OAuth2Authenticator
        //        (
        //            ServerInfo.ClientId,
        //            ServerInfo.ClientSecret,
        //            "profile",
        //            ServerInfo.AuthorizationEndpoint,
        //            ServerInfo.RedirectionEndpoint,
        //            ServerInfo.TokenEndpoint,
        //            null,
        //            isUsingNativeUI: true
        //        );

        //    try
        //    {
        //        var result = await authenticator.RequestAccessTokenAsync(queryValues);

        //        if (result.ContainsKey("access_token"))
        //            account.Properties["access_token"] = result["access_token"];

        //        if (result.ContainsKey("refresh_token"))
        //            account.Properties["refresh_token"] = result["refresh_token"];

        //        store.Save(account, ServiceId);

        //        await App.Current.MainPage.DisplayAlert("WoopWoop", "Refresh suceeded ", "ok");
        //    }
        //    catch (Exception ex)
        //    {
        //        await App.Current.MainPage.DisplayAlert("Oops", "Refresh failed " + ex.Message, "ok");

        //    }
        //}

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
                ProjectHeyAuthentication.IsAuthenticated = e.IsAuthenticated;

                if (account != null)
                    store.Delete(account, ProjectHeyAuthentication.ServiceId);

                store.Save(account = e.Account, ProjectHeyAuthentication.ServiceId);

                SyncProfile();
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Dammit...", "Authentication Failed", "I'll report it");

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

            App.Current.MainPage.DisplayAlert("Dammit... Obviously something went wrong...", e.Message,  "It happens...");
        }

        private void PresentUILoginScreen(OAuth2Authenticator authenticator)
        {
            Xamarin.Auth.Presenters.OAuthLoginPresenter presenter = null;
            presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
            presenter.Login(authenticator);
        }

    }
}