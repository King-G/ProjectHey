using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectHey.DOMAIN;
using ProjectHey.DOMAIN.Contracts;
using Microsoft.EntityFrameworkCore;
using ProjectHey.DOMAIN.Structs;

namespace ProjectHey.DAL
{
    public class UserDB : IUser
    {
        private readonly ProjectHeyContext projectHeyContext = new ProjectHeyContext();

        public async Task<User> CreateAsync(User entity)
        {
  
            projectHeyContext.User.Add(entity);
            await projectHeyContext.SaveChangesAsync();
            await GeneralDB.UpdateLocation(projectHeyContext, "user", entity.Location, entity.Id);
            return entity;  
        }

        public async Task<IEnumerable<User>> CreateRangeAsync(List<User> entities)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i] = await CreateAsync(entities[i]);

            }
            return entities;
        }

        public async Task<User> DeleteAsync(User entity)
        {
            projectHeyContext.User.Remove(projectHeyContext.User.Single(x => x.Id == entity.Id));
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await projectHeyContext.User.CountAsync();
        }

        public async Task<IEnumerable<User>> GetAsync(int skip, int take)
        {
            return await projectHeyContext.User.AsNoTracking().OrderBy(x => x.Id).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<User> GetSimplifiedByIdAsync(int id)
        {
            return await projectHeyContext.User.AsNoTracking()
                 .SingleOrDefaultAsync(x => x.Id == id);
            
        }
        public async Task<User> GetByIdAsync(int id)
        {
            User user =  await projectHeyContext.User.AsNoTracking()
                .Include(x => x.Feedback)
                .Include(x => x.Appsetting)
                .Include(x => x.ReportedUsers)
                .Include(x => x.BlockedUsers)
                .Include(x => x.Connections)
                .Include(x => x.UserCategory)
                .Include(x => x.UserRole)
                .Include(x => x.Messages)
                .Include(x => x.Advertisement)
                .Include(x => x.WatchedAdvertisement)
                .Include(x => x.UserProvider)
                .SingleOrDefaultAsync(x => x.Id == id);
            user.Location = await GeneralDB.GetLocation(projectHeyContext, "user", id);
            foreach (Advertisement a in user.Advertisement) //Neccesary? Do we need the location? yes if we aint gonna request, no if we do.
            {
                a.Location = await GeneralDB.GetLocation(projectHeyContext, "advertisement", a.Id);
            }
            return user;
        }
        public async Task<IEnumerable<User>> GetByLocationAsync(User requestor, int skip, int take)
        {
            //testing required
            return await projectHeyContext.User.AsNoTracking().FromSql(
            @"DECLARE @from geography = geography::STPointFromText([Location])', 4326);
                DECLARE @to geography = geography::STPointFromText('POINT(' + CAST({0} AS VARCHAR(20)) +' ' + CAST({1} AS VARCHAR(20)) +')', 4326);
            SELECT *
            FROM dbo.User
            WHERE @from.STDistance(@to) <= @p0",
            requestor.Location.Longitude,
            requestor.Location.Latitude,
            requestor.Appsetting.Radius)
            .Where(x => 
            !x.Connections.Any(y => y.UserOneId == requestor.Id) &&
            !x.BlockedUsers.Any(y => y.UserId == requestor.Id))
            .OrderBy(x => x.ActivityDate)
            .Skip(skip)
            .Take(take)
            .ToListAsync();
            //When DBGeography comes out...
            //return await projectHeyContext.User.AsNoTracking().Where(x => x.Location.Distance(currLocation) < range)
            //                .OrderBy(x => x.Location.Distance(currLocation)).Skip(skip).Take(take).ToListAsync();
        }
        public async Task<User> GetByUsernameAsync(string username)
        {
            User user= await projectHeyContext.User
                 .Include(x => x.UserCategory)
                 .FirstOrDefaultAsync((x => x.Username == username));
            user.Location = await GeneralDB.GetLocation(projectHeyContext, "user", user.Id);

            return user;
        }
        public async Task<User> UpdateAsync(User entity)
        {
            projectHeyContext.User.Attach(entity);
            projectHeyContext.Entry<User>(entity).State = EntityState.Modified;
            await projectHeyContext.SaveChangesAsync();

            await GeneralDB.UpdateLocation(projectHeyContext, "user", entity.Location, entity.Id);

            return entity;
        }


    }
}
