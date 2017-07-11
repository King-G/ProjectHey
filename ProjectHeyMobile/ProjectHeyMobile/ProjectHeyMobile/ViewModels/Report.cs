using ProjectHeyMobile.ViewModels.Enums;

namespace ProjectHeyMobile.ViewModels
{
    public class Report
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public ReportType ReportType { get; set; } = ReportType.Other;
    }
}
