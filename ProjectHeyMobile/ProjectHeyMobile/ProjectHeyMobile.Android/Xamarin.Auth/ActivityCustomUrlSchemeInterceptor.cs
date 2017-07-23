
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
using Android.Content.PM;
using ProjectHeyMobile.Authentication;

namespace ProjectHeyMobile
{
    //=================================================================
    [Activity(Label = "ActivityCustomUrlSchemeInterceptor", NoHistory = true, LaunchMode = LaunchMode.SingleTop)]
    // Walthrough Step 4
    //      Intercepting/Catching/Detecting [redirect] url change 
    //      App Linking / Deep linking - custom url schemes
    //      
    // 
    [
        IntentFilter
        (
            actions: new[] { Intent.ActionView },
            Categories = new[]
                    {
                        Intent.CategoryDefault,
                        Intent.CategoryBrowsable
                    },
            DataSchemes = new[]
                    {
                        "https://www.facebook.com/connect/login_success.html",
                        "http://www.facebook.com/connect/login_success.html",
                        "https://m.facebook.com/connect/login_success.html",
                        "http://m.facebook.com/connect/login_success.html",
                        "fb139025613314996://localhost/path",
                        "fb139025613314996://authorize",
                    },
            //DataHost = "localhost",
            DataPath = "/oauth2redirect"
        )
    ]
    public class ActivityCustomUrlSchemeInterceptor : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Uri uri = new Uri(Intent.Data.ToString());

            // load redirect_url Page
            ProjectHeyAuthentication.Authenticator.OnPageLoading(uri);

            Finish();
        }
    }
}
