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
    public class UserManager : IUser
    {
        private readonly ConnectionManager connectionManager = new ConnectionManager();
        private readonly SignalRRoomManager signalRRoomManager = new SignalRRoomManager();

        private readonly UserDB userDB = new UserDB();
        public async Task<User> CreateAsync(User entity)
        {
            entity.Username = entity.ResetUsername();
            entity.CreationDate = DateTime.Now;
            entity.ActivityDate = DateTime.Now;
            entity.Appsetting = new AppSetting();
            entity.Appsetting = entity.Appsetting.GetDefaultAppSettings();
            entity.SignalRUser = new SignalRUser();

            return await userDB.CreateAsync(entity);
        }
        public async Task<Connection> CreateConnectionForUser(User requestor)
        {
            IEnumerable<User> potentials = await GetUsersByLocationAsync(requestor, 0, 1);
            User chosenOne = potentials.FirstOrDefault();

            if (chosenOne != null)
            {
                //Create a chatroom for the connections
                SignalRRoom connectionRoom = new SignalRRoom();
                connectionRoom = await signalRRoomManager.CreateAsync(connectionRoom);

                //User sends connection request
                Connection userRequest = new Connection()
                {
                    User = requestor,
                    UserConnection = chosenOne,
                    SignalRRoom = connectionRoom
                };

                //User automatically accepts connection request
                Connection userRequestAccepted = new Connection()
                {
                    User = chosenOne,
                    UserConnection = requestor,
                    SignalRRoom = connectionRoom
                };

                userRequest = await connectionManager.CreateAsync(userRequest);
                userRequestAccepted = await connectionManager.CreateAsync(userRequestAccepted);

                return userRequest;
            }
            else
            {
                //Exception noUserFoundException = new Exception("No user found within radius, expand the range in your appsettings");
                //throw noUserFoundException;
                return null;
            }
        }
        public async Task<IEnumerable<User>> CreateRangeAsync(List<User> entities)
        {
            return await userDB.CreateRangeAsync(entities);
        }

        public async Task<User> DeleteAsync(User entity)
        {
            return await userDB.DeleteAsync(entity);
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await userDB.GetTotalCountAsync();
        }

        public async Task<IEnumerable<User>> GetAsync(int skip, int take)
        {
            return await userDB.GetAsync(skip, take);
        }
        public async Task<User> GetSimplifiedByIdAsync(int id)
        {
            return await userDB.GetSimplifiedByIdAsync(id);
        }
        public async Task<User> GetByFacebookId(string facebookId)
        {
            return await userDB.GetByFacebookId(facebookId);
        }
        public async Task<User> GetByIdAsync(int id)
        {
            return await userDB.GetByIdAsync(id);
        }
        public async Task<IEnumerable<User>> GetUsersByLocationAsync(User requestor, int skip, int take)
        {
            return await userDB.GetUsersByLocationAsync(requestor, skip, take);
        }
        public async Task<User> GetByUsernameAsync(string username)
        {
            return await userDB.GetByUsernameAsync(username);
        }
        public async Task<User> UpdateAsync(User entity)
        {
            return await userDB.UpdateAsync(entity);
        }


    }
}
