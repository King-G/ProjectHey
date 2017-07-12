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
    public class ConnectionManager : IConnection
    {
        private readonly ConnectionDB connectionDB = new ConnectionDB();

        public async Task<Connection> CreateAsync(Connection entity)
        {
            return await connectionDB.CreateAsync(entity);
        }

        public async Task<IEnumerable<Connection>> CreateRangeAsync(List<Connection> entities)
        {
            return await connectionDB.CreateRangeAsync(entities);
        }

        public async Task<Connection> DeleteAsync(Connection entity)
        {
            return await connectionDB.DeleteAsync(entity);
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await connectionDB.GetTotalCountAsync();
        }

        public async Task<IEnumerable<Connection>> GetAsync(int skip, int take)
        {
            return await connectionDB.GetAsync(skip, take);
        }
        public async Task<IEnumerable<Connection>> GetByIdAsync(int id, int skip, int take)
        {
            return await connectionDB.GetByIdAsync(id, skip, take);
        }

        public async Task<IEnumerable<Connection>> GetAllByIdAsync(int id)
        {
            UserManager userManager = new UserManager();

            IEnumerable<Connection> connections = await connectionDB.GetAllByIdAsync(id);
            List<Connection> presentableconnection = new List<Connection>();
            foreach (Connection connection in connections)
            {
                if (connection.UserTwoId == id)
                {
                    User helper =  await userManager.GetSimplifiedByIdAsync(connection.UserOneId);

                    connection.UserOne = connection.UserTwo;
                    connection.UserOneId = connection.UserTwoId;

                    connection.UserTwoId = helper.Id;
                    connection.UserTwo = helper;
                }
                presentableconnection.Add(connection);

            }
            return presentableconnection;
        }
        public async Task<Connection> GetByIdAsync(int id)
        {
            return await connectionDB.GetByIdAsync(id);
        }

        public async Task<Connection> UpdateAsync(Connection entity)
        {
            return await connectionDB.UpdateAsync(entity);
        }

    }
}
