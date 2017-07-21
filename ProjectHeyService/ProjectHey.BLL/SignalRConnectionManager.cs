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
    public class SignalRConnectionManager : ISignalRConnection
    {
        private readonly SignalRConnectionDB signalRConnectionDB = new SignalRConnectionDB();

        public async Task<SignalRConnection> CreateAsync(SignalRConnection entity)
        {
            return await signalRConnectionDB.CreateAsync(entity);
        }

        public async Task<IEnumerable<SignalRConnection>> CreateRangeAsync(List<SignalRConnection> entities)
        {
            return await signalRConnectionDB.CreateRangeAsync(entities);
        }

        public async Task<SignalRConnection> DeleteAsync(SignalRConnection entity)
        {
            return await signalRConnectionDB.DeleteAsync(entity);
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await signalRConnectionDB.GetTotalCountAsync();
        }

        public async Task<IEnumerable<SignalRConnection>> GetAsync(int skip, int take)
        {
            return await signalRConnectionDB.GetAsync(skip, take);
        }

        public async Task<SignalRConnection> GetByIdAsync(int id)
        {
            return await signalRConnectionDB.GetByIdAsync(id);
        }

        public async Task<SignalRConnection> UpdateAsync(SignalRConnection entity)
        {
            return await signalRConnectionDB.UpdateAsync(entity);
        }
    }
}
