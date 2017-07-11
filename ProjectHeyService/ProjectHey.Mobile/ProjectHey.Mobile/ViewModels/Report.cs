using ProjectHey.Mobile.Enums;

namespace ProjectHey.Mobile
{
    public class Report
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public ReportType ReportType { get; set; } = ReportType.Other;
    }
}
