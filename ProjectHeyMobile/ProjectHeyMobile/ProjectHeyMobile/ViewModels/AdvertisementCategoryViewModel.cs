using ProjectHey.DOMAIN;

namespace ProjectHeyMobile.ViewModels
{
    public class AdvertisementCategoryViewModel : BaseViewModel
    {
        private AdvertisementCategory _AdvertisementCategory;

        public AdvertisementCategoryViewModel(AdvertisementCategory AdvertisementCategory)
        {
            _AdvertisementCategory = AdvertisementCategory;
        }
        public AdvertisementCategory AdvertisementCategory
        {
            get { return _AdvertisementCategory; }
            set { SetValue(ref _AdvertisementCategory, value); }
        }

        //#region Private Properties
        //private int _AdvertisementId;
        //private AdvertisementViewModel _Advertisement;
        //private int _CategoryId;
        //private CategoryViewModel _Category; 
        //#endregion

        //#region Public Properties
        //public int AdvertisementId
        //{
        //    get { return _AdvertisementId; }
        //    set { SetValue(ref _AdvertisementId, value); }
        //}
        //public AdvertisementViewModel Advertisement
        //{
        //    get { return _Advertisement; }
        //    set { SetValue(ref _Advertisement, value); }
        //}

        //public int CategoryId
        //{
        //    get { return _CategoryId; }
        //    set { SetValue(ref _CategoryId, value); }
        //}
        //public CategoryViewModel Category
        //{
        //    get { return _Category; }
        //    set { SetValue(ref _Category, value); }
        //} 
        //#endregion
    }
}