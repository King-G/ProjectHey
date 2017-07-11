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
    public class FeedbackManager : IFeedback
    {
        private readonly FeedbackDB feedbackDB = new FeedbackDB();

        public async Task<Feedback> CreateAsync(Feedback entity)
        {
            //if (entity == null)
               // throw new ProjectException<Feedback>("tis leeg", entity, new NullReferenceException());
            return await feedbackDB.CreateAsync(entity);
        }

        public async Task<IEnumerable<Feedback>> CreateRangeAsync(List<Feedback> entities)
        {
            return await feedbackDB.CreateRangeAsync(entities);
        }

        public async Task<Feedback> DeleteAsync(Feedback entity)
        {
            return await feedbackDB.DeleteAsync(entity);
        }

        public async Task<IEnumerable<Feedback>> GetAsync(int skip, int take)
        {
            return await feedbackDB.GetAsync(skip, take);
        }
        public async Task<int> GetTotalCountAsync()
        {
            return await feedbackDB.GetTotalCountAsync();
        }

        public async Task<IEnumerable<Feedback>> GetByRank(int rating, int skip, int take)
        {
            return await feedbackDB.GetByRating(rating, skip, take);
        }

        public async Task<Feedback> GetByIdAsync(int id)
        {
            return await feedbackDB.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Feedback>> GetByRating(int rating, int skip, int take)
        {
            return await feedbackDB.GetByRating(rating, skip, take);
        }

        public async Task<Feedback> UpdateAsync(Feedback entity)
        {
            return await feedbackDB.UpdateAsync(entity);
        }
    }
}
