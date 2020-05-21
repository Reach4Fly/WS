using Gyms.DomainObjects;
using Gyms.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Gyms.ApplicationServices.Repositories
{
    public class InMemoryGymPointRepository : IReadOnlyGymPointRepository,
                                           IGymPointRepository
    {
        private readonly List<GymPoint> _gympoints = new List<GymPoint>();

        public InMemoryGymPointRepository(IEnumerable<GymPoint> gympoints = null)
        {
            if (gympoints != null)
            {
                _gympoints.AddRange(gympoints);
            }
        }

        public Task AddGymPoint(GymPoint gympoint)
        {
            _gympoints.Add(gympoint);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<GymPoint>> GetAllGymPoints()
        {
            return Task.FromResult(_gympoints.AsEnumerable());
        }

        public Task<GymPoint> GetGymPoint(long id)
        {
            return Task.FromResult(_gympoints.Where(gp => gp.Id == id).FirstOrDefault());
        }

        public Task<IEnumerable<GymPoint>> QueryGymPoints(ICriteria<GymPoint> criteria)
        {
            return Task.FromResult(_gympoints.Where(criteria.Filter.Compile()).AsEnumerable());
        }

        public Task RemoveGymPoint(GymPoint gympoint)
        {
            _gympoints.Remove(gympoint);
            return Task.CompletedTask;
        }

        public Task UpdateGymPoint(GymPoint gympoint)
        {
            var foundGymPoint = GetGymPoint(gympoint.Id).Result;
            if (foundGymPoint == null)
            {
                AddGymPoint(gympoint);
            }
            else
            {
                if (foundGymPoint != gympoint)
                {
                    _gympoints.Remove(foundGymPoint);
                    _gympoints.Add(gympoint);
                }
            }
            return Task.CompletedTask;
        }
    }
}
