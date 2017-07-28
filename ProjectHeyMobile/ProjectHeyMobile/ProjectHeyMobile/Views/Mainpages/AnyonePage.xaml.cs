using ProjectHey.DOMAIN;
using ProjectHeyMobile.ViewModels;
using ProjectHeyMobile.Views.Chatpages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectHeyMobile.Views.Mainpages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnyonePage : ContentPage
    {
        public AnyonePage()
        {
            InitializeComponent();
        }

        private async void Anyone_Clicked(object sender, EventArgs e)
        {
            ChatViewModel chatVM = new ChatViewModel(App.Main.User.FacebookCity.SignalRRoom);
            await App.Main.PageService.PushAsync(new ChatPage(chatVM));
        }
    }
}