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
    public class CategoryDB : ICategory
    {
        private readonly ProjectHeyContext projectHeyContext = new ProjectHeyContext();

        public async Task<Category> CreateAsync(Category entity)
        {
            projectHeyContext.Category.Add(entity);
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }
        public async Task<Category> CreateProtectedCategory(Category entity, string password)
        {
            //See BLL for password use
            return await CreateAsync(entity);
        }
        public async Task<IEnumerable<Category>> CreateRangeAsync(List<Category> entities)
        {
            projectHeyContext.Category.AddRange(entities);
            await projectHeyContext.SaveChangesAsync();
            return entities;
        }

        public async Task<Category> DeleteAsync(Category entity)
        {
            projectHeyContext.Category.Remove(projectHeyContext.Category.Single(x => x.Id == entity.Id));
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }
        public async Task<int> GetTotalUsersForCategory(Category entity)
        {
            return await projectHeyContext.UserCategory.AsNoTracking()
                .Where(x => x.Category == entity)
                .CountAsync();
        }

        public async Task<int> GetTotalSignalRUsersForCategory(Category entity)
        {
            return await projectHeyContext.SignalRRoom.AsNoTracking()
                .Where(x => x.Id == entity.SignalRRoomId)
                .CountAsync();
        }
        public async Task<int> GetTotalCountAsync()
        {
            return await projectHeyContext.Category.CountAsync();
        }
        public async Task<IEnumerable<Category>> GetAsync(int skip, int take)
        {
            return await projectHeyContext.Category.AsNoTracking()
                .OrderBy(x => x.TotalUsers)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetOrderByTotalUsersAsync(int skip, int take)
        {
            return await GetAsync(skip, take);
        }

        public async Task<IEnumerable<Category>> GetOrderByTotalSignalRUsersAsync(int skip, int take)
        {
            return await projectHeyContext.Category.AsNoTracking()
                .OrderBy(x => x.TotalSignalRUsers)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetBySearchNameAsync(string searchname, int skip, int take)
        {
            return await projectHeyContext.Category.AsNoTracking()
                .Where(x => x.Name.Contains(searchname))
                .OrderBy(x => x.Id)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }
        public async Task<Category> GetByIdAsync(int id)
        {
            return await projectHeyContext.Category.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Category> GetByNameAsync(string name)
        {
            return await projectHeyContext.Category.FirstOrDefaultAsync(x => x.Name == name);
        }
        public async Task<Category> UpdateAsync(Category entity)
        {
            projectHeyContext.Category.Attach(entity);
            projectHeyContext.Entry<Category>(entity).State = EntityState.Modified;
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

        
    }
}
