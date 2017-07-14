using ProjectHey.DOMAIN;

namespace ProjectHeyMobile.ViewModels
{
    public class ReportViewModel : BaseViewModel
    {
        private Report _Report;

        public ReportViewModel(Report Report)
        {
            _Report = Report;
        }
        public Report Report
        {
            get { return _Report; }
            set { SetValue(ref _Report, value); }
        }
    }
}