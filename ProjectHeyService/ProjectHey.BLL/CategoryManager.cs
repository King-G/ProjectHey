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
    public class CategoryManager : ICategory
    {
        private readonly CategoryDB categoryDB = new CategoryDB();

        public async Task<Category> CreateAsync(Category entity)
        {
            return await categoryDB.CreateAsync(entity);
        }

        public async Task<IEnumerable<Category>> CreateRangeAsync(List<Category> entities)
        {
            return await categoryDB.CreateRangeAsync(entities);
        }

        public async Task<Category> DeleteAsync(Category entity)
        {
            return await categoryDB.DeleteAsync(entity);
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await categoryDB.GetTotalCountAsync();
        }

        public async Task<IEnumerable<Category>> GetAsync(int skip, int take)
        {
            return await categoryDB.GetAsync(skip, take);
        }
        public async Task<Category> GetByIdAsync(int id)
        {
            return await categoryDB.GetByIdAsync(id);
        }
        public async Task<Category> GetByNameAsync(string name)
        {
            return await categoryDB.GetByNameAsync(name);
        }

        public async Task<Category> UpdateAsync(Category entity)
        {
            return await categoryDB.UpdateAsync(entity);
        }
    }
}
