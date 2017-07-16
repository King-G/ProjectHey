using ProjectHeyMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProjectHeyMobile.ViewModels.Enums;

namespace ProjectHeyMobile.Views.Chatpages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessageView : ViewCell
    {
        public MessageView()
        {
            InitializeComponent();
        }
        protected override void OnBindingContextChanged()
        {
            switch ((BindingContext as MessageViewModel).MessageType)
            {
                case MessageType.Received:
                    MessageGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.2, GridUnitType.Star) });
                    MessageGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.8, GridUnitType.Star) });
                    MessageFrame.HorizontalOptions = LayoutOptions.End;
                    MessageFrame.Margin = new Thickness(0, 5, 20, 5);
                    MessageGrid.Children.Add(MessageFrame, 1, 0);
                    break;

                default:
                case MessageType.Send:
                    MessageGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.8, GridUnitType.Star) });
                    MessageGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.2, GridUnitType.Star) });
                    MessageFrame.HorizontalOptions = LayoutOptions.Start;
                    MessageFrame.Margin = new Thickness(20, 5, 0, 5);
                    MessageGrid.Children.Add(MessageFrame, 0, 0);
                    break;
            }
            base.OnBindingContextChanged();
        }
    }
}