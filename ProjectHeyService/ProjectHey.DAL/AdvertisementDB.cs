using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectHey.DOMAIN;
using ProjectHey.DOMAIN.Contracts;
using Microsoft.EntityFrameworkCore;
using ProjectHey.DOMAIN.Enums;

namespace ProjectHey.DAL
{
    public class AdvertisementDB : IAdvertisement
    {
        private readonly ProjectHeyContext projectHeyContext = new ProjectHeyContext();

        public async Task<Advertisement> CreateAsync(Advertisement entity)
        {
            projectHeyContext.Advertisement.Add(entity);
            await projectHeyContext.SaveChangesAsync();
            await GeneralDB.UpdateLocation(projectHeyContext, "advertisement", entity.Location, entity.Id);
            return entity;
        }

        public async Task<IEnumerable<Advertisement>> CreateRangeAsync(List<Advertisement> entities)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i] = await CreateAsync(entities[i]);
            }
            return entities;
        }

        public async Task<Advertisement> DeleteAsync(Advertisement entity)
        {
            projectHeyContext.Advertisement.Remove(projectHeyContext.Advertisement.Single(x => x.Id == entity.Id));
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await projectHeyContext.Advertisement.CountAsync();
        }

        public async Task<IEnumerable<Advertisement>> GetAsync(int skip, int take)
        {
            return await projectHeyContext.Advertisement.AsNoTracking().OrderBy(x => x.Id).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<IEnumerable<Advertisement>> GetByAdvertisementTypeAsync(AdvertisementType advertisementType)
        {
            return await projectHeyContext.Advertisement.AsNoTracking()
                .Include(x => x.Location)
                .Include(x => x.AdvertisementCategory)
                .OrderBy(x => x.Id)
                .Where(x => x.AdvertisementCategory.Any(y => y.Advertisement.AdvertisementType == advertisementType))
                .ToListAsync();
        }

        public async Task<Advertisement> GetByIdAsync(int id)
        {
            Advertisement advertisement = await projectHeyContext.Advertisement.AsNoTracking()
                 .FirstOrDefaultAsync(x => x.Id == id);
            advertisement.Location = await GeneralDB.GetLocation(projectHeyContext, "advertisement", id);
            return advertisement;
        }

        public async Task<IEnumerable<Advertisement>> GetByLocationAsync(User requestor, int skip, int take)
        {
            //testing required
            return await projectHeyContext.Advertisement.AsNoTracking().FromSql(
            @"DECLARE @from geography = geography::STPointFromText([Location])', 4326);
                DECLARE @to geography = geography::STPointFromText('POINT(' + CAST({0} AS VARCHAR(20)) +' ' + CAST({1} AS VARCHAR(20)) +')', 4326);
            SELECT *
            FROM dbo.Advertisement
            WHERE @from.STDistance(@to) <= @p0",
            requestor.Location.Longitude,
            requestor.Location.Latitude,
            requestor.Appsetting.Radius)
            .Skip(skip)
            .Take(take)
            .ToListAsync();
        }

        public async Task<Advertisement> UpdateAsync(Advertisement entity)
        {
            projectHeyContext.Advertisement.Attach(entity);
            projectHeyContext.Entry<Advertisement>(entity).State = EntityState.Modified;
            await projectHeyContext.SaveChangesAsync();

            await GeneralDB.UpdateLocation(projectHeyContext, "advertisement", entity.Location, entity.Id);

            return entity;
        }

    }
}
