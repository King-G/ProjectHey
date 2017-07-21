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
    public class SignalRMessageManager : ISignalRMessage
    {
        private readonly SignalRMessageDB signalRMessageDB = new SignalRMessageDB();

        public async Task<SignalRMessage> CreateAsync(SignalRMessage entity)
        {
            return await signalRMessageDB.CreateAsync(entity);
        }

        public async Task<IEnumerable<SignalRMessage>> CreateRangeAsync(List<SignalRMessage> entities)
        {
            return await signalRMessageDB.CreateRangeAsync(entities);
        }

        public async Task<SignalRMessage> DeleteAsync(SignalRMessage entity)
        {
            return await signalRMessageDB.DeleteAsync(entity);
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await signalRMessageDB.GetTotalCountAsync();
        }

        public async Task<IEnumerable<SignalRMessage>> GetAsync(int skip, int take)
        {
            return await signalRMessageDB.GetAsync(skip, take);
        }

        public async Task<SignalRMessage> GetByIdAsync(int id)
        {
            return await signalRMessageDB.GetByIdAsync(id);
        }
        public async Task<SignalRMessage> UpdateAsync(SignalRMessage entity)
        {
            return await signalRMessageDB.UpdateAsync(entity);
        }
    }
}
