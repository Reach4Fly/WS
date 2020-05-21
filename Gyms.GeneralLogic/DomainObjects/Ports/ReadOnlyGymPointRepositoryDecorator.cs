using Gyms.DomainObjects;
using Gyms.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Gyms.DomainObjects.Repositories
{
    public abstract class ReadOnlyGymPointRepositoryDecorator : IReadOnlyGymPointRepository
    {
        private readonly IReadOnlyGymPointRepository _gympointRepository;

        public ReadOnlyGymPointRepositoryDecorator(IReadOnlyGymPointRepository gympointRepository)
        {
            _gympointRepository = gympointRepository;
        }

        public virtual async Task<IEnumerable<GymPoint>> GetAllGymPoints()
        {
            return await _gympointRepository?.GetAllGymPoints();
        }

        public virtual async Task<GymPoint> GetGymPoint(long id)
        {
            return await _gympointRepository?.GetGymPoint(id);
        }

        public virtual async Task<IEnumerable<GymPoint>> QueryGymPoints(ICriteria<GymPoint> criteria)
        {
            return await _gympointRepository?.QueryGymPoints(criteria);
        }
    }
}
