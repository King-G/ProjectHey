using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Auth;
using Xamarin.Auth.XamarinForms;
using Xamarin.Forms;

namespace ProjectHeyMobile.Views.Rootpages
{
    [Preserve(AllMembers = true)]
    public class CustomAuthenticatorPage : ContentPage
    {
        public Authenticator Authenticator
        {
            get;
            set;
        } = null;

        public CustomAuthenticatorPage()
            : base()
        {
            this.Title = "Authenticator Page";

            return;
        }

        public CustomAuthenticatorPage(Authenticator a)
            : this()
        {
            this.Authenticator = a;
            return;
        }

        bool was_shown = false;

        public void Authentication_Completed(object sender, AuthenticatorCompletedEventArgs e)
        {
            return;
        }
        public void Authentication_Error(object sender, AuthenticatorErrorEventArgs e)
        {
            return;
        }

        public void Authentication_BrowsingCompleted(object sender, EventArgs e)
        {
            return;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (was_shown)
            {
                Navigation.PopAsync(true);
            }
            else
            {
                was_shown = true;
            }

            return;
        }

        protected override void OnDisappearing()
        {
            return;
        }
    }

}