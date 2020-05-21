using Gyms.ApplicationServices.Ports.Cache;
using Gyms.DomainObjects;
using Gyms.DomainObjects.Ports;
using Gyms.DomainObjects.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Gyms.InfrastructureServices.Repositories
{
    public class CachedReadOnlyGymPointRepository : ReadOnlyGymPointRepositoryDecorator
    {
        private readonly IDomainObjectsCache<GymPoint> _gympointsCache;

        public CachedReadOnlyGymPointRepository(IReadOnlyGymPointRepository gympointRepository, 
                                             IDomainObjectsCache<GymPoint> gympointsCache)
            : base(gympointRepository)
            => _gympointsCache = gympointsCache;

        public async override Task<GymPoint> GetGymPoint(long id)
            => _gympointsCache.GetObject(id) ?? await base.GetGymPoint(id);

        public async override Task<IEnumerable<GymPoint>> GetAllGymPoints()
            => _gympointsCache.GetObjects() ?? await base.GetAllGymPoints();

        public async override Task<IEnumerable<GymPoint>> QueryGymPoints(ICriteria<GymPoint> criteria)
            => _gympointsCache.GetObjects()?.Where(criteria.Filter.Compile()) ?? await base.QueryGymPoints(criteria);

    }
}
