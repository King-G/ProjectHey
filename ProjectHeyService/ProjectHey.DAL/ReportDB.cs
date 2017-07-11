using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectHey.DOMAIN;
using ProjectHey.DOMAIN.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ProjectHey.DAL
{
    public class ReportDB : IReport
    {
        private readonly ProjectHeyContext projectHeyContext = new ProjectHeyContext();

        public async Task<Report> CreateAsync(Report entity)
        {
            projectHeyContext.Report.Add(entity);
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Report>> CreateRangeAsync(List<Report> entities)
        {
            projectHeyContext.Report.AddRange(entities);
            await projectHeyContext.SaveChangesAsync();
            return entities;
        }

        public async Task<Report> DeleteAsync(Report entity)
        {
            projectHeyContext.Report.Remove(projectHeyContext.Report.Single(x => x.Id == entity.Id));
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await projectHeyContext.Report.CountAsync();
        }

        public async Task<IEnumerable<Report>> GetAsync(int skip, int take)
        {
            return await projectHeyContext.Report.AsNoTracking().OrderBy(x => x.Id).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<Report> GetByIdAsync(int id)
        {
            return await projectHeyContext.Report.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Report> UpdateAsync(Report entity)
        {
            projectHeyContext.Report.Attach(entity);
            projectHeyContext.Entry<Report>(entity).State = EntityState.Modified;
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }
    }
}
