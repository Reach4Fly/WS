using Gyms.DomainObjects;
using Gyms.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gyms.ApplicationServices.GetGymPointListUseCase
{
    public class GetGymPointListUseCaseResponse : UseCaseResponse
    {
        public IEnumerable<GymPoint> GymPoints { get; }

        public GetGymPointListUseCaseResponse(IEnumerable<GymPoint> gympoints) => GymPoints = gympoints;
    }
}
