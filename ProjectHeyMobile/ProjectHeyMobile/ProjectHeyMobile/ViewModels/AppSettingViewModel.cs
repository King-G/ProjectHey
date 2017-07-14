using System;
using System.Collections.Generic;
using System.Linq;
using ProjectHeyMobile.Utils;
using ProjectHey.DOMAIN;
using ProjectHey.DOMAIN.Enums;

namespace ProjectHeyMobile.ViewModels
{
    public class AppSettingViewModel : BaseViewModel
    {
        private AppSetting  _AppSetting;

        public AppSettingViewModel(AppSetting AppSetting)
        {
            _AppSetting = AppSetting;
        }
        public AppSetting AppSetting
        {
            get { return _AppSetting; }
            set { SetValue(ref _AppSetting, value); }
        }

        //#region Private Properties
        //private int _id;
        //private int _radius;
        //private int _maximumNotifications;
        //private int _maximumConversations;
        //private Language _language;
        //private bool _sound;
        //private bool _vibrate;
        //private int _userId;
        //private UserViewModel _user; 
        //#endregion

        //#region Public Properties
        //public int Id
        //{
        //    get { return _id; }
        //    set { SetValue(ref _id, value); }
        //}

        //public int Radius
        //{
        //    get { return _radius; }
        //    set { SetValue(ref _radius, value); }
        //}
        //public int MaximumNotifications
        //{
        //    get { return _maximumNotifications; }
        //    set { SetValue(ref _maximumNotifications, value); }
        //}
        //public int MaximumConversations
        //{
        //    get { return _maximumConversations; }
        //    set { SetValue(ref _maximumConversations, value); }
        //}
        //public Language Language
        //{
        //    get { return _language; }
        //    set { SetValue(ref _language, value); }
        //}
        //public bool Sound
        //{
        //    get { return _sound; }
        //    set { SetValue(ref _sound, value); }
        //}
        //public bool Vibrate
        //{
        //    get { return _vibrate; }
        //    set { SetValue(ref _vibrate, value); }
        //}
        //public int UserId
        //{
        //    get { return _userId; }
        //    set { SetValue(ref _userId, value); }
        //}
        //public UserViewModel User
        //{
        //    get { return _user; }
        //    set { SetValue(ref _user, value); }
        //} 
        //#endregion
        public List<string> Languages
        {
            get
            {
                return Enum.GetNames(typeof(Language)).Select(b => b.SplitCamelCase()).ToList();
            }
        }
    }
}
