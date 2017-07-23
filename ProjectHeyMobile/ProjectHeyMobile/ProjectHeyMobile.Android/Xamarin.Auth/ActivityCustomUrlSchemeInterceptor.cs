
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
          DataSchemes = new[]
                  {
                        "http://127.0.0.1",
                        "https://127.0.0.1",
                        "https://localhost/path",
                        "http://localhost/path",
                        "https://localhost",
                        "http://localhost",
                        "https://www.facebook.com/connect/login_success.html",
                        "fb139025613314996", //Projecthey fb id
                        "xamarin-auth",
              /*
              "urn:ietf:wg:oauth:2.0:oob",
              "urn:ietf:wg:oauth:2.0:oob.auto",
              "http://localhost:PORT",
              "https://localhost:PORT",
              "http://127.0.0.1:PORT",
              "https://127.0.0.1:PORT",              
              "http://[::1]:PORT", 
              "https://[::1]:PORT", 
              */
                  },
          //DataHost = "localhost",
          DataHosts = new[]
                  {
                        "localhost",
                        "authorize",                // Facebook in fb1889013594699403://authorize 
          },
          DataPaths = new[]
                  {
                        "/",                        // Facebook
						"/oauth2redirect",          // Google
                        "/oauth2redirectpath",      // MeetUp
          },
          AutoVerify = true
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


            this.Finish();

            return;

        }

    }
}
