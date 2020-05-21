using Gyms.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Gyms.ApplicationServices.Ports.Gateways.Database
{
    public interface IGymDatabaseGateway
    {
        Task AddGymPoint(GymPoint gympoint);

        Task RemoveGymPoint(GymPoint gympoint);

        Task UpdateGymPoint(GymPoint gympoint);

        Task<GymPoint> GetGymPoint(long id);

        Task<IEnumerable<GymPoint>> GetAllGymPoints();

        Task<IEnumerable<GymPoint>> QueryGymPoints(Expression<Func<GymPoint, bool>> filter);

    }
}
