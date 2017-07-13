using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjectHeyMobile.ViewModels.Interfaces
{
    public interface IPageService
    {
        void DisplayAlert(string title, string message, string cancel);
        Task<bool> DisplayAlert(string title, string message, string accept, string cancel);

        Task PushAsync(Page page);
        Task PushModelAsync(Page page);


    }
}
