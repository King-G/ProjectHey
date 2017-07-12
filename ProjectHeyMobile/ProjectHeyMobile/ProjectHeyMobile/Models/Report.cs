using ProjectHeyMobile.Models.Enums;

namespace ProjectHeyMobile.Models
{
    public class Report
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public ReportType ReportType { get; set; } = ReportType.Other;
    }
}
