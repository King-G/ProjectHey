using System;
using System.Collections.Generic;
using System.Linq;
using ProjectHeyMobile.Utils;
using ProjectHey.DOMAIN;
using ProjectHey.DOMAIN.Enums;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using Refit;
using ProjectHeyMobile.APICommunication;
using System.Net.Http;
using ProjectHeyMobile.Authentication;
using Newtonsoft.Json;
using ProjectHeyMobile.Views.Utilitypages;

namespace ProjectHeyMobile.ViewModels
{
    public class AppSettingViewModel : BaseViewModel
    {
        private AppSetting  _AppSetting;

        public ICommand SaveChangesCommand { get; private set; }

        public AppSettingViewModel(AppSetting AppSetting)
        {
            _AppSetting = AppSetting;
            SaveChangesCommand = new Command<AppSettingViewModel>(async x => await SaveChanges());
        }
        private async Task SaveChanges()
        {
            try
            {
                var projectHeyAPI = RestService.For<IProjectHeyAPIAppsettings>(new HttpClient(new AuthenticatedHttpClientHandler()) { BaseAddress = new Uri(ProjectHeyAuthentication.ProjectHeyAPIEndpoint) });
                var response = await projectHeyAPI.Update(_AppSetting);
                _AppSetting = JsonConvert.DeserializeObject<APISingleResponse<AppSetting>>(response).Value;
            }
            catch (Exception exception)
            {
                await App.Main.PageService.PushAsync(new ErrorPage(exception));
            }

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
