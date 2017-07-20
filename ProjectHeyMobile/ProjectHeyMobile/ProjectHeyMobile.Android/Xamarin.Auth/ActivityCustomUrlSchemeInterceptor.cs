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
    [Activity(Label = "ActivityCustomUrlSchemeInterceptor", NoHistory = true, LaunchMode = LaunchMode.SingleTop)]
    [
        IntentFilter
        (
            actions: new[] { Intent.ActionView },
            Categories = new[]
                    {
                        Intent.CategoryDefault,
                        Intent.CategoryBrowsable
                    },
            DataScheme = "com.mutatemundum.hey",
            DataHost = "projecthey.eu.auth0.com",
            DataPathPrefix = "/android/com.mutatemundum.hey/callback"
        )
    ]
    public class ActivityCustomUrlSchemeInterceptor : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Uri uri = new Uri(Intent.Data.ToString());

            // load redirect_url Page
            AuthenticationState.Authenticator.OnPageLoading(uri);

            Finish();
        }
    }
}