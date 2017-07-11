using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectHey.DOMAIN;
using ProjectHey.DOMAIN.Contracts;
using ProjectHey.DAL;

namespace ProjectHey.BLL
{
    public class ReportManager : IReport
    {
        private readonly ReportDB reportDB = new ReportDB();

        public async Task<Report> CreateAsync(Report entity)
        {
            return await reportDB.CreateAsync(entity);
        }

        public async Task<IEnumerable<Report>> CreateRangeAsync(List<Report> entities)
        {
            return await reportDB.CreateRangeAsync(entities);
        }

        public async Task<Report> DeleteAsync(Report entity)
        {
            return await reportDB.DeleteAsync(entity);
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await reportDB.GetTotalCountAsync();
        }

        public async Task<IEnumerable<Report>> GetAsync(int skip, int take)
        {
            return await reportDB.GetAsync(skip, take);
        }

        public async Task<Report> GetByIdAsync(int id)
        {
            return await reportDB.GetByIdAsync(id);
        }

        public async Task<Report> UpdateAsync(Report entity)
        {
            return await reportDB.UpdateAsync(entity);
        }
    }
}
