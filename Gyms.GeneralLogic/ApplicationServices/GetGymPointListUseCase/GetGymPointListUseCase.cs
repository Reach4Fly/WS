using System.Threading.Tasks;
using System.Collections.Generic;
using Gyms.DomainObjects;
using Gyms.DomainObjects.Ports;
using Gyms.ApplicationServices.Ports;

namespace Gyms.ApplicationServices.GetGymPointListUseCase
{
    public class GetGymPointListUseCase : IGetGymPointListUseCase
    {
        private readonly IReadOnlyGymPointRepository _readOnlyGymPointRepository;

        public GetGymPointListUseCase(IReadOnlyGymPointRepository readOnlyGymPointRepository) 
            => _readOnlyGymPointRepository = readOnlyGymPointRepository;

        public async Task<bool> Handle(GetGymPointListUseCaseRequest request, IOutputPort<GetGymPointListUseCaseResponse> outputPort)
        {
            IEnumerable<GymPoint> gympoints = null;
            if (request.GymPointId != null)
            {
                var gympoint = await _readOnlyGymPointRepository.GetGymPoint(request.GymPointId.Value);
                gympoints = (gympoint != null) ? new List<GymPoint>() { gympoint } : new List<GymPoint>();
                
            }
            else if (request.District != null)
            {
                gympoints = await _readOnlyGymPointRepository.QueryGymPoints(new DistrictCriteria(request.District));
            }
            else
            {
                gympoints = await _readOnlyGymPointRepository.GetAllGymPoints();
            }
            outputPort.Handle(new GetGymPointListUseCaseResponse(gympoints));
            return true;
        }
    }
}
