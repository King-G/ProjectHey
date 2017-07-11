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
    public class FeedbackDB : IFeedback
    {
        private readonly ProjectHeyContext projectHeyContext = new ProjectHeyContext();

        public async Task<Feedback> CreateAsync(Feedback entity)
        {
            projectHeyContext.Feedback.Add(entity);
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Feedback>> CreateRangeAsync(List<Feedback> entities)
        {
            projectHeyContext.Feedback.AddRange(entities);
            await projectHeyContext.SaveChangesAsync();
            return entities;
        }

        public async Task<Feedback> DeleteAsync(Feedback entity)
        {
            projectHeyContext.Feedback.Remove(projectHeyContext.Feedback.Single(x => x.Id == entity.Id));
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Feedback>> GetAsync(int skip, int take)
        {
            return await projectHeyContext.Feedback.AsNoTracking().OrderBy(x => x.Id).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await projectHeyContext.Feedback.CountAsync();
        }

        public async Task<IEnumerable<Feedback>> GetByRating(int rating, int skip, int take)
        {
            return await projectHeyContext.Feedback.AsNoTracking().Where(x => x.Rating == rating).OrderBy(x => x.Id).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<Feedback> GetByIdAsync(int id)
        {
            return await projectHeyContext.Feedback.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Feedback> UpdateAsync(Feedback entity)
        {
            projectHeyContext.Feedback.Attach(entity);
            projectHeyContext.Entry<Feedback>(entity).State = EntityState.Modified;
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }
    }
}
