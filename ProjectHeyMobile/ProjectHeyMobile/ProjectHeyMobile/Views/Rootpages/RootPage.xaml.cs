using Newtonsoft.Json;
using ProjectHeyMobile.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Auth;
using Xamarin.Auth.XamarinForms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectHeyMobile.Views.Rootpages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RootPage : MasterDetailPage
    {
        Account account;
        AccountStore store;
        public RootPage()
        {
            InitializeComponent();

            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
            store = AccountStore.Create();
            account = store.FindAccountsForService(ProjectHeyAuthentication.ServiceId).FirstOrDefault();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (!ProjectHeyAuthentication.IsLoggedIn)
            {
                PopUpLogin();
            }
        }
        public void PopUpLogin()
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

            ProjectHeyAuthentication.Authenticator = authenticator;

            CustomAuthenticatorPage authenticationPage = new CustomAuthenticatorPage();
            App.Current.MainPage.Navigation.PushAsync(authenticationPage);
            //Xamarin.Auth.Presenters.OAuthLoginPresenter presenter = null;
            //presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
            //presenter.Login(authenticator);
        }

        async void OnAuthCompleted(object sender, AuthenticatorCompletedEventArgs e)
        {
            var authenticator = sender as OAuth2Authenticator;

            //if (authenticator != null)
            //{
            //    authenticator.Completed -= OnAuthCompleted;
            //    authenticator.Error -= OnAuthError;
            //}

            if (e.IsAuthenticated)
            {
                if (account != null)
                    store.Delete(account, ProjectHeyAuthentication.ServiceId);

                account = e.Account;
                store.Save(account, ProjectHeyAuthentication.ServiceId);


                ProjectHeyAuthentication.FacebookToken = account.Properties["access_token"];

                //App.FacebookModel = await GetProfile();
                //await App.Main.LoadUser(App.FacebookModel);
                //App.Current.MainPage = new NavigationPage(new RootPage());

                //GET CREDENTIALS
                //CognitoAWSCredentials credentials
                //    = new CognitoAWSCredentials(ProjectHeyAuthentication.AWSIdentityPool, ProjectHeyAuthentication.AWSRegionEndpoint);

                //credentials.AddLogin("graph.facebook.com", accessToken);

                //credentials.ClearCredentials();
                //ImmutableCredentials ic = credentials.GetCredentials();

                //ProjectHeyAuthentication.AWSAccessKey = ic.AccessKey;
                //ProjectHeyAuthentication.AWSSecretKey = ic.SecretKey;

            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Dammit...", "Authentication Failed", "I'll report it");

            }
        }

        void OnAuthError(object sender, AuthenticatorErrorEventArgs e)
        {

            var authenticator = sender as OAuth2Authenticator;

            //if (authenticator != null)
            //{
            //    authenticator.Completed -= OnAuthCompleted;
            //    authenticator.Error -= OnAuthError;

            //}

            App.Current.MainPage.DisplayAlert("Dammit... Obviously something went wrong...", e.Message, "It happens...");
        }
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as RootPageMenuItem;
            if (item == null)
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            Detail = new NavigationPage(page);
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }

        async Task<FacebookModel> GetProfile()
        {
            try
            {
                //#region WHILE WE WAIT FOR  AUTH0 TO GET THEIR SHIT TOGETHER
                //FacebookModel facebookModel = new FacebookModel()
                //{
                //    name = "Karim Gabsi",
                //    family_name = "Gabsi",
                //    given_name = "Karim",
                //    email = "gabsikarim@gmail.com",
                //    age_range = new AgeRange() { min = 21 },
                //    gender = "male",
                //    birthday = "01/16/1991",
                //    location = new Location() { id = "114521328558541", name = "Kortrijk" }

                //};

                //return facebookModel;
                //#endregion


                var request = new OAuth2Request("GET", ProjectHeyAuthentication.ApiEndpoint, null, account);

                var response = await request.GetResponseAsync();
                var responseData = await response.GetResponseTextAsync();

                FacebookModel facebookModel = JsonConvert.DeserializeObject<FacebookModel>(responseData);

                return facebookModel;
                //var imageRequest = new OAuth2Request("GET", new Uri(imageUrl), null, account);
                //var stream = await (await imageRequest.GetResponseAsync()).GetResponseStreamAsync();
                //profileImage.Source = ImageSource.FromStream(() => stream);


            }
            catch (Exception exception)
            {
                await App.Current.MainPage.DisplayAlert("Oops", "Get data failure: " + exception.Message + "\r\nHas the access token expired?", "ok");
                return null;
            }
        }

        #region TOKEN REFRESH
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

        #endregion
    }
}