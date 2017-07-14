using ProjectHey.DOMAIN;
using ProjectHeyMobile.ViewModels.Enums;
using ProjectHeyMobile.ViewModels.Structs;
using System.Collections.Generic;

namespace ProjectHeyMobile.ViewModels
{
    public class AdvertisementViewModel : BaseViewModel
    {
        private Advertisement _Advertisement;

        public AdvertisementViewModel()
        {

        }
        public Advertisement Advertisement
        {
            get { return _Advertisement; }
            set { SetValue(ref _Advertisement, value); }
        }

        //#region Private Properties
        //private int _Id;
        //private string _PictureURL;
        //private string _AdvertisementURL;
        //private AdvertisementType _AdvertisementType;
        //private int _AmountRemaining;
        //private int _UserId;
        //private UserViewModel _User;
        //private Location _Location;
        //private ICollection<AdvertisementCategoryViewModel> _AdvertisementCategory;
        //private ICollection<UserAdvertisementViewModel> _WatchedAdvertisement; 
        //#endregion

        //#region Public Properties
        //public int Id
        //{
        //    get { return _Id; }
        //    set { SetValue(ref _Id, value); }
        //}
        //public string PictureURL
        //{
        //    get { return _PictureURL; }
        //    set { SetValue(ref _PictureURL, value); }
        //}
        //public string AdvertisementURL
        //{
        //    get { return _AdvertisementURL; }
        //    set { SetValue(ref _AdvertisementURL, value); }
        //}
        //public AdvertisementType AdvertisementType
        //{
        //    get { return _AdvertisementType; }
        //    set { SetValue(ref _AdvertisementType, value); }
        //}
        //public int AmountRemaining
        //{
        //    get { return _AmountRemaining; }
        //    set { SetValue(ref _AmountRemaining, value); }
        //}
        //public int UserId
        //{
        //    get { return _UserId; }
        //    set { SetValue(ref _UserId, value); }
        //}
        //public UserViewModel User
        //{
        //    get { return _User; }
        //    set { SetValue(ref _User, value); }
        //}
        //public Location Location
        //{
        //    get { return _Location; }
        //    set { SetValue(ref _Location, value); }
        //}
        //public ICollection<AdvertisementCategoryViewModel> AdvertisementCategory
        //{
        //    get { return _AdvertisementCategory; }
        //    set { SetValue(ref _AdvertisementCategory, value); }
        //}
        //public ICollection<UserAdvertisementViewModel> WatchedAdvertisement
        //{
        //    get { return _WatchedAdvertisement; }
        //    set { SetValue(ref _WatchedAdvertisement, value); }
        //} 
        //#endregion
    }
}