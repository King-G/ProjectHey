using Newtonsoft.Json;
using ProjectHey.DOMAIN;
using ProjectHeyMobile.APICommunication;
using ProjectHeyMobile.ViewModels.Service;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHeyMobile.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public readonly IPageService PageService = new PageService();

        private User _user;

        public User User
        {
            get { return _user; }
            set { SetValue(ref _user,  value); }
        }

        #region Methods
        //public async Task SaveChangesAsync()
        //{
        //    try
        //    {
        //        var projectHeyAPI = RestService.For<IProjectHeyAPI>("https://qg2v8wkg9k.execute-api.eu-west-2.amazonaws.com/Prod/api");
        //        var response = await projectHeyAPI.SyncUser(_user);
        //        User userSynced = JsonConvert.DeserializeObject<APISingleResponse<User>>(response).Value;
        //        if (userSynced != null)
        //        {
        //            _user = userSynced;
        //            await PageService.DisplayAlert("Done", "Changes were saved", "OK");
        //        }
        //        else
        //        {
        //            await PageService.DisplayAlert("Oops", "Something went wrong trying to sync", "OK");
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        await PageService.DisplayAlert("Oops", exception.Message, "OK");
        //    }
        //} 
        #endregion

    }
}
