using ProjectHeyMobile.APICommunication;
using ProjectHeyMobile.ViewModels.Enums;
using ProjectHeyMobile.ViewModels.Interfaces;
using Refit;
using System.Windows.Input;
using System;

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

        private readonly IPageService _pageService;

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

        public ICommand GetAppSettings;
        public AppSettingViewModel()
        {

        }
        public AppSettingViewModel(IPageService pageService)
        {
            _pageService = pageService;
        }

        public async void SaveChanges()
        {
            try
            {
                var projectHeyAPI = RestService.For<IProjectHeyAPI>("https://qg2v8wkg9k.execute-api.eu-west-2.amazonaws.com/Prod/api");
                var response = projectHeyAPI.AppSettingsUpdate(this);
                //Arrived here, is it actually saved well? maybe a response is needed!
                //No response needed, so no serialization, fire and forget.
            }
            catch (System.Exception exception)
            {
                _pageService.DisplayAlert("Oops", exception.Message, "OK");
            }
        }
    }
}
