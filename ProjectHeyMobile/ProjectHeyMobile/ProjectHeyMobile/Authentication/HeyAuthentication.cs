
using Amazon;
using Amazon.CognitoIdentity;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace ProjectHeyMobile.Authentication
{
    public class HeyAuthentication : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public const string FacebookAppId = "139025613314996";
        private string _FacebookToken;

        public string FacebookToken
        {
            get { return GetValue<string>(); }
            set { UpdateValue(ref _FacebookToken, value); }
        }
        private OAuthSettings _OAuthSettings = new OAuthSettings(FacebookAppId, "uId", "https://m.facebook.com/dialog/oauth", "https://www.facebook.com/connect/login_success.html");

        public OAuthSettings OAuthSettings
        {
            get { return _OAuthSettings; }
            set { SetValue(ref _OAuthSettings, value); }
        }

        public bool IsLoggedIn
        {
            get { return !string.IsNullOrWhiteSpace(_FacebookToken); }
        }

        private CognitoAWSCredentials _AWSCredentials = 
            new CognitoAWSCredentials("eu-west-2:a2455afb-c917-464f-9c8a-e90697708a6e", RegionEndpoint.EUWest2);

        public CognitoAWSCredentials AWSCredentials
        {
            get { return _AWSCredentials; }
            set { SetValue(ref _AWSCredentials, value); }
        }



        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void UpdateValue<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value))
                return;

            backingField = value;

            Application.Current.Properties[propertyName] = value;
            Application.Current.SavePropertiesAsync();

            OnPropertyChanged(propertyName);
        }
        protected T GetValue<T>([CallerMemberName] string propertyName = null)
        {
            return (T)Application.Current.Properties[propertyName];
        }

        protected void SetValue<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value))
                return;

            backingField = value;

            OnPropertyChanged(propertyName);
        }
    }
}
