using Gyms.ApplicationServices.Ports.Gateways.Database;
using Gyms.DomainObjects;
using Gyms.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Gyms.ApplicationServices.Repositories
{
    public class DbGymPointRepository : IReadOnlyGymPointRepository,
                                     IGymPointRepository
    {
        private readonly IGymDatabaseGateway _databaseGateway;

        public DbGymPointRepository(IGymDatabaseGateway databaseGateway)
            => _databaseGateway = databaseGateway;

        public async Task<GymPoint> GetGymPoint(long id)
            => await _databaseGateway.GetGymPoint(id);

        public async Task<IEnumerable<GymPoint>> GetAllGymPoints()
            => await _databaseGateway.GetAllGymPoints();

        public async Task<IEnumerable<GymPoint>> QueryGymPoints(ICriteria<GymPoint> criteria)
            => await _databaseGateway.QueryGymPoints(criteria.Filter);

        public async Task AddGymPoint(GymPoint gympoint)
            => await _databaseGateway.AddGymPoint(gympoint);

        public async Task RemoveGymPoint(GymPoint gympoint)
            => await _databaseGateway.RemoveGymPoint(gympoint);

        public async Task UpdateGymPoint(GymPoint gympoint)
            => await _databaseGateway.UpdateGymPoint(gympoint);
    }
}
