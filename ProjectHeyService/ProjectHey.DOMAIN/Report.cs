using ProjectHey.DOMAIN.Enums;

namespace ProjectHey.DOMAIN
{
    public class Report
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public ReportType ReportType { get; set; } = ReportType.Other;
    }
}
