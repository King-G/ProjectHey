
namespace ProjectHeyMobile.Models
{
    public class Reported
    {
        public int ReporterUserId { get; set; }
        public User ReporterUser { get; set; }

        public int ReportedUserId { get; set; }
        public User ReportedUser { get; set; }

        public int ReportId { get; set; }
        public Report Report { get; set; }

    }
}
