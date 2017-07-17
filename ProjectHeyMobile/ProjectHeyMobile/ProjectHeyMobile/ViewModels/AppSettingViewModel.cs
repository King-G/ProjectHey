using System;
using System.Collections.Generic;
using System.Linq;
using ProjectHeyMobile.Utils;
using ProjectHey.DOMAIN;
using ProjectHey.DOMAIN.Enums;
using System.ComponentModel;

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
        public List<string> Languages
        {
            get
            {
                return Enum.GetNames(typeof(Language)).Select(b => b.SplitCamelCase()).ToList();
            }
        }
    }
}
