using ProjectHey.DOMAIN;
using ProjectHey.DOMAIN.Enums;
using ProjectHeyMobile.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectHeyMobile.ViewModels
{
    public class FeedbackViewModel : BaseViewModel
    {
        private Feedback _Feedback;

        public FeedbackViewModel()
        {
            _Feedback = new Feedback();
        }
        public Feedback Feedback
        {
            get { return _Feedback; }
            set { SetValue(ref _Feedback, value); }
        }

        public List<string> FeedbackTypes
        {
            get
            {
                return Enum.GetNames(typeof(FeedbackType)).Select(b => b.SplitCamelCase()).ToList();
            }
        }
    }
}