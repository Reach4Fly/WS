using Gyms.DomainObjects;
using Gyms.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Gyms.ApplicationServices.GetGymPointListUseCase
{
    public class DistrictCriteria : ICriteria<GymPoint>
    {
        public string District { get; }

        public DistrictCriteria(string district)
            => District = district;

        public Expression<Func<GymPoint, bool>> Filter
            => (gp => gp.District == District);
    }
}
