using Gyms.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Xunit;
using Gyms.ApplicationServices.GetGymPointListUseCase;
using System.Linq.Expressions;
using Gyms.ApplicationServices.Ports;
using Gyms.DomainObjects.Ports;
using Gyms.ApplicationServices.Repositories;

namespace Gyms.WebService.Core.Tests
{
    public class GetGymPointListUseCaseTest
    {
        private InMemoryGymPointRepository CreateGymPointtRepository()
        {
            var repo = new InMemoryGymPointRepository(new List<GymPoint> {
                new GymPoint { Id = 1,  NameObject="Фитнес клуб «Зебра»",
                        NameZone="зал тренажерный",
                        District="Административный округ: Восточный административный округ",
                        Area="район Богородское",
                        Address="Краснобогатырская улица, дом 2, строение 1 ",
                        Email="",
                        WebSite="fitnes.ru  "},
                new GymPoint { Id = 2,NameObject="Физкультурно-оздоровительный комплекс «Центр Вешняки»",
                        NameZone="зал тренажерный",
                        District="Административный округ: Восточный административный округ  ",
                        Area="район Вешняки",
                        Address="Вешняковская улица, дом 29Д",
                        Email="mu_sdc@mail.ru",
                        WebSite="sport-vesh.ru "},
                
            });
            return repo;
        }
        [Fact]
        public void TestGetAllGymPoints()
        {
            var useCase = new GetGymPointListUseCase(CreateGymPointtRepository());
            var outputPort = new OutputPort();
                        
            Assert.True(useCase.Handle(GetGymPointListUseCaseRequest.CreateAllGymPointsRequest(), outputPort).Result);
            Assert.Equal<int>(2, outputPort.GymPoints.Count());
            Assert.Equal(new long[] { 1, 2}, outputPort.GymPoints.Select(gp => gp.Id));
        }

        [Fact]
        public void TestGetAllGymPointsFromEmptyRepository()
        {
            var useCase = new GetGymPointListUseCase(new InMemoryGymPointRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetGymPointListUseCaseRequest.CreateAllGymPointsRequest(), outputPort).Result);
            Assert.Empty(outputPort.GymPoints);
        }

        [Fact]
        public void TestGetGymPoint()
        {
            var useCase = new GetGymPointListUseCase(CreateGymPointtRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetGymPointListUseCaseRequest.CreateGymPointRequest(2), outputPort).Result);
            Assert.Single(outputPort.GymPoints, gp => 2 == gp.Id);
        }

        [Fact]
        public void TestTryGetNotExistingGymPoint()
        {
            var useCase = new GetGymPointListUseCase(CreateGymPointtRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetGymPointListUseCaseRequest.CreateGymPointRequest(999), outputPort).Result);
            Assert.Empty(outputPort.GymPoints);
        }
      
    }

    class OutputPort : IOutputPort<GetGymPointListUseCaseResponse>
    {
        public IEnumerable<GymPoint> GymPoints { get; private set; }

        public void Handle(GetGymPointListUseCaseResponse response)
        {
            GymPoints = response.GymPoints;
        }
    }
}
