using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Gyms.DomainObjects.Ports
{
    public interface IReadOnlyGymPointRepository
    {
        Task<GymPoint> GetGymPoint(long id);

        Task<IEnumerable<GymPoint>> GetAllGymPoints();

        Task<IEnumerable<GymPoint>> QueryGymPoints(ICriteria<GymPoint> criteria);

    }

    public interface IGymPointRepository
    {
        Task AddGymPoint(GymPoint gympoint);

        Task RemoveGymPoint(GymPoint gympoint);

        Task UpdateGymPoint(GymPoint gympoint);
    }
}
