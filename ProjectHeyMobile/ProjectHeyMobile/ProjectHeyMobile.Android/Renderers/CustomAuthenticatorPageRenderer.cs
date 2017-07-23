using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using ProjectHeyMobile.Views.Rootpages;
using Xamarin.Forms;
using Xamarin.Auth;
using ProjectHeyMobile.Droid.Renderers;

[assembly:
    ExportRenderer
        (
            typeof(CustomAuthenticatorPage),
            typeof(CustomAuthenticatorPageRenderer)
        )
]
namespace ProjectHeyMobile.Droid.Renderers
{
    [global::Android.Runtime.Preserve(AllMembers = true)]
    public class CustomAuthenticatorPageRenderer : Xamarin.Forms.Platform.Android.PageRenderer
    {
        protected Xamarin.Auth.Authenticator Authenticator = null;
        protected CustomAuthenticatorPage authenticator_page = null;

        //global::Android.App.Activity loginActivity = new global::Android.App.Activity();
        global::Android.App.Activity loginActivity;
        global::Android.Content.Intent ui_object;
        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            
            // this is a ViewGroup - so should be able to load an AXML file and FindView<>
            //global::Android.App.Activity activity = this.Context as global::Android.App.Activity;

            authenticator_page = (CustomAuthenticatorPage)base.Element;

            Authenticator = authenticator_page.Authenticator;
            Authenticator.Completed += Authentication_Completed;
            Authenticator.Error += Authentication_Error;

            loginActivity = this.Context as global::Android.App.Activity;
            ui_object = Authenticator.GetUI(loginActivity);
           
            loginActivity.StartActivity(ui_object);
            
            //return;
        }


        protected void Authentication_Completed(object sender, AuthenticatorCompletedEventArgs e)
        {
            authenticator_page.Authentication_Completed(sender, e);
            loginActivity.StopService(ui_object);
            return;
        }

        protected void Authentication_Error(object sender, AuthenticatorErrorEventArgs e)
        {
            authenticator_page.Authentication_Error(sender, e);

            return;
        }

        protected void Authentication_BrowsingCompleted(object sender, EventArgs e)
        {
            authenticator_page.Authentication_BrowsingCompleted(sender, e);
            return;
        }
    }
}