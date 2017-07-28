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
        public async Task<Category> CreateProtectedCategory(Category entity, string password)
        {
            Category existingCategory = await GetByNameAsync("#" + entity.Name);
            if (existingCategory == null)
            {
                SignalRRoomManager signalRRoomManager = new SignalRRoomManager();
                SignalRRoom categoryRoom = new SignalRRoom()
                {
                    Roomname = "#" + entity.Name
                };

                if (!string.IsNullOrWhiteSpace(password))
                {
                    categoryRoom.Password = password;
                }

                categoryRoom = await signalRRoomManager.CreateAsync(categoryRoom);

                entity.SignalRRoom = categoryRoom;

                return await categoryDB.CreateProtectedCategory(entity, password);
            }
            else
            {
                Exception exception = new Exception("Category already exist!");
                throw exception;
            }
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

        public async Task<int> GetTotalUsersForCategory(Category entity)
        {
            return await categoryDB.GetTotalUsersForCategory(entity);
        }

        public async Task<int> GetTotalSignalRUsersForCategory(Category entity)
        {
            return await categoryDB.GetTotalSignalRUsersForCategory(entity);
        }

        public async Task<IEnumerable<Category>> GetOrderByTotalUsersAsync(int skip, int take)
        {
            return await categoryDB.GetOrderByTotalUsersAsync(skip, take);
        }

        public async Task<IEnumerable<Category>> GetOrderByTotalSignalRUsersAsync(int skip, int take)
        {
            return await categoryDB.GetOrderByTotalSignalRUsersAsync(skip, take);
        }

        public async Task<IEnumerable<Category>> GetBySearchNameAsync(string searchname, int skip, int take)
        {
            return await categoryDB.GetBySearchNameAsync(searchname,skip, take);
        }

        
    }
}
