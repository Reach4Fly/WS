using Gyms.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gyms.ApplicationServices.GetGymPointListUseCase
{
    public class GetGymPointListUseCaseRequest : IUseCaseRequest<GetGymPointListUseCaseResponse>
    {
        public string District { get; private set; }
        public long? GymPointId { get; private set; }

        private GetGymPointListUseCaseRequest()
        { }

        public static GetGymPointListUseCaseRequest CreateAllMedPointsRequest()
        {
            return new GetGymPointListUseCaseRequest();
        }

        public static GetGymPointListUseCaseRequest CreateMedPointRequest(long gympointId)
        {
            return new GetGymPointListUseCaseRequest() { GymPointId = gympointId };
        }
        public static GetGymPointListUseCaseRequest CreateDistrictGymPointsRequest(string district)
        {
            return new GetGymPointListUseCaseRequest() { District = district };
        }
    }
}
