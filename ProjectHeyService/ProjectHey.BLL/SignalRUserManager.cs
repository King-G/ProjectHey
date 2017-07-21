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
    public class SignalRUserManager : ISignalRUser
    {
        private readonly SignalRUserDB signalRUserDB = new SignalRUserDB();

        public async Task<SignalRUser> CreateAsync(SignalRUser entity)
        {
            return await signalRUserDB.CreateAsync(entity);
        }

        public async Task<IEnumerable<SignalRUser>> CreateRangeAsync(List<SignalRUser> entities)
        {
            return await signalRUserDB.CreateRangeAsync(entities);
        }

        public async Task<SignalRUser> DeleteAsync(SignalRUser entity)
        {
            return await signalRUserDB.DeleteAsync(entity);
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await signalRUserDB.GetTotalCountAsync();
        }

        public async Task<IEnumerable<SignalRUser>> GetAsync(int skip, int take)
        {
            return await signalRUserDB.GetAsync(skip, take);
        }

        public async Task<SignalRUser> GetByIdAsync(int id)
        {
            return await signalRUserDB.GetByIdAsync(id);
        }

        public async Task<SignalRUser> UpdateAsync(SignalRUser entity)
        {
            return await signalRUserDB.UpdateAsync(entity);
        }
    }
}
