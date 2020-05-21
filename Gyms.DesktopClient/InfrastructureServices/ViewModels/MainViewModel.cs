using Gyms.ApplicationServices.GetGymPointListUseCase;
using Gyms.ApplicationServices.Ports;
using Gyms.DomainObjects;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Gyms.DesktopClient.InfrastructureServices.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IGetGymPointListUseCase _getGymPointListUseCase;

        public MainViewModel(IGetGymPointListUseCase getGymPointListUseCase)
            => _getGymPointListUseCase = getGymPointListUseCase;

        private Task<bool> _loadingTask;
        private GymPoint _currentGymPoint;
        private ObservableCollection<GymPoint> _gympoints;

        public event PropertyChangedEventHandler PropertyChanged;

        public GymPoint CurrentGymPoint
        {
            get => _currentGymPoint; 
            set
            {
                if (_currentGymPoint != value)
                {
                    _currentGymPoint = value;
                    OnPropertyChanged(nameof(CurrentGymPoint));
                }
            }
        }

        private async Task<bool> LoadGymPoints()
        {
            var outputPort = new OutputPort();
            bool result = await _getGymPointListUseCase.Handle(GetGymPointListUseCaseRequest.CreateAllGymPointsRequest(), outputPort);
            if (result)
            {
                GymPoints = new ObservableCollection<GymPoint>(outputPort.GymPoints);
            }
            return result;
        }

        public ObservableCollection<GymPoint> GymPoints
        {
            get 
            {
                if (_loadingTask == null)
                {
                    _loadingTask = LoadGymPoints();
                }
                
                return _gympoints; 
            }
            set
            {
                if (_gympoints != value)
                {
                    _gympoints = value;
                    OnPropertyChanged(nameof(GymPoints));
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private class OutputPort : IOutputPort<GetGymPointListUseCaseResponse>
        {
            public IEnumerable<GymPoint> GymPoints { get; private set; }

            public void Handle(GetGymPointListUseCaseResponse response)
            {
                if (response.Success)
                {
                    GymPoints = new ObservableCollection<GymPoint>(response.GymPoints);
                }
            }
        }
    }
}
