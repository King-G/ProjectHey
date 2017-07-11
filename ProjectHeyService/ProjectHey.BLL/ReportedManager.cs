using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectHey.DOMAIN;
using ProjectHey.DOMAIN.Contracts;
using ProjectHey.DAL;
using ProjectHey.DOMAIN.Enums;

namespace ProjectHey.BLL
{
    public class ReportedManager : IReported
    {
        private readonly ReportedDB reportedDB = new ReportedDB();

        public async Task<Reported> CreateAsync(Reported entity)
        {
            return await reportedDB.CreateAsync(entity);
        }

        public async Task<IEnumerable<Reported>> CreateRangeAsync(List<Reported> entities)
        {
            return await reportedDB.CreateRangeAsync(entities);
        }

        public async Task<Reported> DeleteAsync(Reported entity)
        {
            return await reportedDB.DeleteAsync(entity);
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await reportedDB.GetTotalCountAsync();
        }

        public async Task<IEnumerable<Reported>> GetAsync(int skip, int take)
        {
            return await reportedDB.GetAsync(skip, take);
        }

        public async Task<Reported> GetByIdAsync(int id)
        {
            return await reportedDB.GetByIdAsync(id);
        }
        public async Task<IEnumerable<Reported>> GetByReportedUserIdAsync(int reportedUserId, int skip, int take)
        {
            return await reportedDB.GetByReportedUserIdAsync(reportedUserId, skip, take);
        }
        public async Task<IEnumerable<Reported>> GetByReporterUserIdAsync(int reporterUserId, int skip, int take)
        {
            return await reportedDB.GetByReporterUserIdAsync(reporterUserId, skip, take);
        }

        public async Task<IEnumerable<Reported>> GetByReportType(ReportType reportType)
        {
            return await reportedDB.GetByReportType(reportType);
        }

        public async Task<IEnumerable<Reported>> GetReportDetails(Report entity)
        {
            return await reportedDB.GetReportDetails(entity);
        }

        public async Task<Reported> UpdateAsync(Reported entity)
        {
            return await reportedDB.UpdateAsync(entity);
        }
    }
}
