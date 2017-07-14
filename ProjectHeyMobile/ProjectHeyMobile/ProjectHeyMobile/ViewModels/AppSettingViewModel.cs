using ProjectHeyMobile.APICommunication;
using ProjectHeyMobile.ViewModels.Enums;
using ProjectHeyMobile.ViewModels.Service;
using Refit;
using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using ProjectHeyMobile.Utils;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ProjectHeyMobile.ViewModels
{
    public class AppSettingViewModel : BaseViewModel
    {
        private int _id;
        private int _radius;
        private int _maximumNotifications;
        private int _maximumConversations;
        private Language _language;
        private bool _sound;
        private bool _vibrate;
        private int _userId;
        private UserViewModel _user;

        public int Id
        {
            get { return _id; }
            set { SetValue(ref _id, value); }
        }

        public int Radius
        {
            get { return _radius; }
            set { SetValue(ref _radius, value); }
        }
        public int MaximumNotifications
        {
            get { return _maximumNotifications; }
            set { SetValue(ref _maximumNotifications, value); }
        }
        public int MaximumConversations
        {
            get { return _maximumConversations; }
            set { SetValue(ref _maximumConversations, value); }
        }
        public Language Language
        {
            get { return _language; }
            set { SetValue(ref _language, value); }
        }
        public bool Sound
        {
            get { return _sound; }
            set { SetValue(ref _sound, value); }
        }
        public bool Vibrate
        {
            get { return _vibrate; }
            set { SetValue(ref _vibrate, value); }
        }
        public int UserId
        {
            get { return _userId; }
            set { SetValue(ref _userId, value); }
        }
        public UserViewModel User
        {
            get { return _user; }
            set { SetValue(ref _user, value); }
        }
        public List<string> Languages
        {
            get
            {
                return Enum.GetNames(typeof(Language)).Select(b => b.SplitCamelCase()).ToList();
            }
        }

        public async Task SaveChanges()
        {
            try
            {
                var projectHeyAPI = RestService.For<IProjectHeyAPI>("https://qg2v8wkg9k.execute-api.eu-west-2.amazonaws.com/Prod/api");
                var response = await projectHeyAPI.AppSettingsUpdate(this);
                AppSettingViewModel apsvm = JsonConvert.DeserializeObject<ProjectHeyAPISingleResponse<AppSettingViewModel>>(response).Value;
                if (apsvm != null)
                {
                    await App.User.PageService.DisplayAlert("Done", "Appsettings were saved", "OK");
                }
                else
                {
                    await App.User.PageService.DisplayAlert("Oops", "Something went wrong trying to sync settings", "OK");
                }
            }
            catch (Exception exception)
            {
                await App.User.PageService.DisplayAlert("Oops", exception.Message, "OK");

            }
        }
    }
}
