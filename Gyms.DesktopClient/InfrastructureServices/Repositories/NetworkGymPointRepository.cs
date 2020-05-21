using Gyms.ApplicationServices.Ports.Cache;
using Gyms.DomainObjects;
using Gyms.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Gyms.InfrastructureServices.Repositories
{
    public class NetworkGymPointRepository : NetworkRepositoryBase, IReadOnlyGymPointRepository
    {
        private readonly IDomainObjectsCache<GymPoint> _gympointCache;

        public NetworkGymPointRepository(string host, ushort port, bool useTls, IDomainObjectsCache<GymPoint> gympointCache)
            : base(host, port, useTls)
            => _gympointCache = gympointCache;

        public async Task<GymPoint> GetGymPoint(long id)
            => CacheAndReturn(await ExecuteHttpRequest<GymPoint>($"gympoints/{id}"));

        public async Task<IEnumerable<GymPoint>> GetAllGymPoints()
            => CacheAndReturn(await ExecuteHttpRequest<IEnumerable<GymPoint>>($"gympoints"), allObjects: true);

        public async Task<IEnumerable<GymPoint>> QueryGymPoints(ICriteria<GymPoint> criteria)
            => CacheAndReturn(await ExecuteHttpRequest<IEnumerable<GymPoint>>($"gympoints"), allObjects: true)
               .Where(criteria.Filter.Compile());

        private IEnumerable<GymPoint> CacheAndReturn(IEnumerable<GymPoint> gympoints, bool allObjects = false)
        {
            if (allObjects)
            {
                _gympointCache.ClearCache();
            }
            _gympointCache.UpdateObjects(gympoints, DateTime.Now.AddDays(1), allObjects);
            return gympoints;
        }

        private GymPoint CacheAndReturn(GymPoint gympoint)
        {
            _gympointCache.UpdateObject(gympoint, DateTime.Now.AddDays(1));
            return gympoint;
        }
    }
}
