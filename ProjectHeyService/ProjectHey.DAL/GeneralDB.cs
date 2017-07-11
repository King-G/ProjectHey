using Microsoft.EntityFrameworkCore;
using ProjectHey.DOMAIN.Structs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectHey.DAL
{
    public static class GeneralDB
    {

        public static async Task UpdateLocation(DbContext ctx, string table, Location location, int id)
        {
            string query = String.Format(@"UPDATE [dbo].[{0}] SET Location = geography::STPointFromText('POINT(' + CAST({1} AS VARCHAR(20)) + ' ' + CAST({2} AS VARCHAR(20)) + ')', 4326) WHERE(ID = {3})"
            , table.ToLower(), location.Longitude.ToString().Replace(',', '.'), location.Latitude.ToString().Replace(',', '.'), id);
            await ctx.Database.ExecuteSqlCommandAsync(query);
        }
        public static async Task<Location> GetLocation(DbContext ctx, string table, int id)
        {
            Location location = new Location();

            using (var command = ctx.Database.GetDbConnection().CreateCommand())
            {
                string query = String.Format("SELECT Location.Lat AS Latitude, Location.Long AS Longitude FROM [dbo].[{0}] WHERE Id = {1}"
                    , table, id);
                command.CommandText = query;
                ctx.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (await result.ReadAsync())
                        {
                            location.Latitude = result.GetDouble(0);
                            location.Longitude = result.GetDouble(1);
                        }
                    }

                }
            }

            return location;
        }
    }
}
