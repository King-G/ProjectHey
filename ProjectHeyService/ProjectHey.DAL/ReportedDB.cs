using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectHey.DOMAIN;
using ProjectHey.DOMAIN.Contracts;
using Microsoft.EntityFrameworkCore;
using ProjectHey.DOMAIN.Enums;

namespace ProjectHey.DAL
{
    public class ReportedDB : IReported
    {
        private readonly ProjectHeyContext projectHeyContext = new ProjectHeyContext();

        public async Task<Reported> CreateAsync(Reported entity)
        {
            projectHeyContext.Reported.Add(entity);
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Reported>> CreateRangeAsync(List<Reported> entities)
        {
            projectHeyContext.Reported.AddRange(entities);
            await projectHeyContext.SaveChangesAsync();
            return entities;
        }

        public async Task<Reported> DeleteAsync(Reported entity)
        {
            projectHeyContext.Reported.Remove(projectHeyContext.Reported.Single(x => x.ReporterUserId == entity.ReporterUserId && x.ReportedUserId == entity.ReportedUserId));
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await projectHeyContext.Reported.CountAsync();
        }

        public async Task<IEnumerable<Reported>> GetAsync(int skip, int take)
        {
            return await projectHeyContext.Reported.AsNoTracking().OrderBy(x => x.ReportedUserId).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<Reported> GetByIdAsync(int id)
        {
            return await projectHeyContext.Reported.SingleOrDefaultAsync(x => x.ReportedUserId == id);
        }
        public async Task<IEnumerable<Reported>> GetByReportedUserIdAsync(int reportedUserId, int skip, int take)
        {
            return await projectHeyContext.Reported.AsNoTracking().Where(x => x.ReporterUserId == reportedUserId).OrderBy(x => x.ReporterUserId).Skip(skip).Take(take).ToListAsync();
        }
        public async Task<IEnumerable<Reported>> GetByReporterUserIdAsync(int reporterUserId, int skip, int take)
        {
            return await projectHeyContext.Reported.AsNoTracking().Where(x => x.ReporterUserId == reporterUserId).OrderBy(x => x.ReporterUserId).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<IEnumerable<Reported>> GetByReportType(ReportType reportType)
        {
            return await projectHeyContext.Reported.AsNoTracking()
                .Include(x => x.Report)
                .Where(x => x.Report.ReportType == reportType)
                .ToListAsync();
        }

        public async Task<IEnumerable<Reported>> GetReportDetails(Report entity)
        {
            return await projectHeyContext.Reported.AsNoTracking()
                            .Where(x => x.Report.Id == entity.Id)
                            .ToListAsync();
        }

        public async Task<Reported> UpdateAsync(Reported entity)
        {
            projectHeyContext.Reported.Attach(entity);
            projectHeyContext.Entry<Reported>(entity).State = EntityState.Modified;
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }
    }
}
