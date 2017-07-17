using ProjectHey.DOMAIN;
using ProjectHey.DOMAIN.Enums;
using ProjectHeyMobile.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectHeyMobile.ViewModels
{
    public class ReportViewModel : BaseViewModel
    {
        private Report _Report;
        private int _ReportedUserId;

        private string _Username;

        public string Username
        {
            get { return _Username; }
            set { SetValue(ref _Username, value); }
        }

        public ReportViewModel(int reportedUserId)
        {
            _ReportedUserId = reportedUserId;
            _Report = new Report();
            _Username = "Mothafuckaaa";
        }
        public Report Report
        {
            get { return _Report; }
            set { SetValue(ref _Report, value); }
        }

        public List<string> ReportTypes
        {
            get
            {
                return Enum.GetNames(typeof(ReportType)).Select(b => b.SplitCamelCase()).ToList();
            }
        }
    }
}