using ProjectHey.DOMAIN;

namespace ProjectHeyMobile.ViewModels
{
    public class FeedbackViewModel : BaseViewModel
    {
        private Feedback _Feedback;

        public FeedbackViewModel(Feedback Feedback)
        {
            _Feedback = Feedback;
        }
        public Feedback Feedback
        {
            get { return _Feedback; }
            set { SetValue(ref _Feedback, value); }
        }
    }
}