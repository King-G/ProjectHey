//using System.Net.Http;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectHey.Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConnectionPage : ContentPage
    {
        //private HttpClient client = new HttpClient();
        //private ObservableCollection<MessageViewModel> messages;
        public ConnectionPage()
        {
            InitializeComponent();
            //var messages = new List<Message>();

        }
        protected override void OnAppearing()
        {
            //var jsonmessages = await client.GetStringAsync(messageapi);
            //var objectmessages = JsonConvert.DeserializeObject<List<MessageViewModel>>(jsonmessages);

            //var objectmessages = new List<MessageViewModel>() { new MessageViewModel() { Id= 1,  Body = "Test" }, new MessageViewModel() { Id = 2, Body = "Test" } };
            //messages = new ObservableCollection<MessageViewModel>(objectmessages);

            //lvMessages.ItemsSource = messages;
            base.OnAppearing();
        }

        void OnAdd(object sender, System.EventArgs e)
        {
        }

        void OnUpdate(object sender, System.EventArgs e)
        {
        }

        void OnDelete(object sender, System.EventArgs e)
        {
        }

    }
}