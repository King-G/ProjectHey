using ProjectHeyMobile.Authentication;
using ProjectHeyMobile.Views.Utilitypages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Auth;
using Xamarin.Auth.Presenters;
using Xamarin.Auth.XamarinForms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectHeyMobile.Views.Rootpages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        Account account;
        AccountStore store;
        public StartPage()
        {
            InitializeComponent();
            this.Title = "Hey. {Alpha 1.0.0}";

            store = AccountStore.Create();
            account = store.FindAccountsForService(ProjectHeyAuthentication.ServiceId).FirstOrDefault();
            this.BindingContext = this;

            
            buttonHey.Clicked += ButtenHey_Clicked;
            buttonFacebook.Clicked += ButtonFacebook_Clicked;
        }

        private void ButtonFacebook_Clicked(object sender, EventArgs e)
        {
            PopUpLogin();
        }
        protected override void OnAppearing()
        {
            if (ProjectHeyAuthentication.IsLoggedIn)
            {
                buttonHey.IsVisible = true;
                buttonFacebook.IsVisible = false;
            }
            else
            {
                buttonFacebook.IsVisible = true;
                buttonHey.IsVisible = false;
            }
            base.OnAppearing();

        }
        private void ButtenHey_Clicked(object sender, EventArgs e)
        {
            //Loading screen
            //App.Current.MainPage = new NavigationPage(new LoadingPage());

            //GET INFO | Load App
            //FacebookModel facebooModel = GetProfile().Result;
            //App.LoadUser(facebooModel);

            //SET ROOT PAGE
            App.Current.MainPage = new NavigationPage(new RootPage()); ;
        }
        public void PopUpLogin()
        {
            OAuth2Authenticator authenticator = new OAuth2Authenticator
            (
                clientId: ProjectHeyAuthentication.ClientId,
                //clientSecret: ProjectHeyAuthentication.ClientSecret,
                scope: ProjectHeyAuthentication.Scope,
                authorizeUrl: ProjectHeyAuthentication.AuthorizationEndpoint,
                redirectUrl: ProjectHeyAuthentication.RedirectionEndpoint,
                //accessTokenUrl: ProjectHeyAuthentication.TokenEndpoint,
                getUsernameAsync: null,
                isUsingNativeUI: true
            );

            authenticator.Completed += OnAuthCompleted;
            authenticator.Error += OnAuthError;

            ProjectHeyAuthentication.Authenticator = authenticator;

            OAuthLoginPresenter presenter =  new OAuthLoginPresenter();
            presenter.Completed += Presenter_Completed;
            presenter.Login(authenticator);
            
        }

        private void Presenter_Completed(object sender, AuthenticatorCompletedEventArgs e)
        {
            //(sender as OAuth2Authenticator).OnCancelled();

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

            App.Current.MainPage.DisplayAlert("Dammit... Obviously something went wrong...", e.Message, "It happens...");
        }
    }
}