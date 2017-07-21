using ProjectHeyMobile.ViewModels;
using ProjectHeyMobile.Views.Utilitypages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHeyMobile.Authentication
{
    public class FacebookViewModel : BaseViewModel
    {
        private FacebookModel _FacebookModel;
        public FacebookModel FacebookModel
        {
            get { return _FacebookModel; }
            set { SetValue(ref _FacebookModel, value); }
        }

        public async Task SetFacebookUserProfileAsync(string accessToken)
        {
            var facebookServices = new FacebookServices();

            try
            {
                FacebookModel = await facebookServices.GetFacebookProfileAsync(accessToken);
            }
            catch (Exception exception)
            {
                await App.Current.MainPage.Navigation.PushModalAsync(new ErrorPage(exception));
            }
        }
    }
}
