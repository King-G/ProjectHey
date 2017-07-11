using ProjectHey.DOMAIN.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectHey.DOMAIN.Contracts
{
    public interface IReported : IGeneric<Reported>
    {
        Task<IEnumerable<Reported>> GetByReporterUserIdAsync(int reporterUserId, int skip, int take);
        Task<IEnumerable<Reported>> GetByReportedUserIdAsync(int reportedUserId, int skip, int take);
        Task<IEnumerable<Reported>> GetReportDetails(Report entity);

        Task<IEnumerable<Reported>> GetByReportType(ReportType reportType);


    }
}
