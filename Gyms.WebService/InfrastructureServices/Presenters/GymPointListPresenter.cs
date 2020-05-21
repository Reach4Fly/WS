using Gyms.ApplicationServices.GetGymPointListUseCase;
using System.Net;
using Newtonsoft.Json;
using Gyms.ApplicationServices.Ports;

namespace Gyms.InfrastructureServices.Presenters
{
    public class GymPointListPresenter : IOutputPort<GetGymPointListUseCaseResponse>
    {
        public JsonContentResult ContentResult { get; }

        public GymPointListPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(GetGymPointListUseCaseResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound);
            ContentResult.Content = response.Success ? JsonConvert.SerializeObject(response.GymPoints) : JsonConvert.SerializeObject(response.Message);
        }
    }
}
