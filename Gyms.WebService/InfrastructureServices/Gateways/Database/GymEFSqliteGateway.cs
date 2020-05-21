using Gyms.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using Gyms.ApplicationServices.Ports.Gateways.Database;

namespace Gyms.InfrastructureServices.Gateways.Database
{
    public class GymEFSqliteGateway : IGymDatabaseGateway
    {
        private readonly GymContext _gymContext;

        public GymEFSqliteGateway(GymContext GymContext)
            => _gymContext = GymContext;

        public async Task<GymPoint> GetGymPoint(long id)
           => await _gymContext.GymPoints.Where(gp => gp.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<GymPoint>> GetAllGymPoints()
            => await _gymContext.GymPoints.ToListAsync();
          
        public async Task<IEnumerable<GymPoint>> QueryGymPoints(Expression<Func<GymPoint, bool>> filter)
            => await _gymContext.GymPoints.Where(filter).ToListAsync();

        public async Task AddGymPoint(GymPoint gympoint)
        {
            _gymContext.GymPoints.Add(gympoint);
            await _gymContext.SaveChangesAsync();
        }

        public async Task UpdateGymPoint(GymPoint gympoint)
        {
            _gymContext.Entry(gympoint).State = EntityState.Modified;
            await _gymContext.SaveChangesAsync();
        }

        public async Task RemoveGymPoint(GymPoint gympoint)
        {
            _gymContext.GymPoints.Remove(gympoint);
            await _gymContext.SaveChangesAsync();
        }

    }
}
