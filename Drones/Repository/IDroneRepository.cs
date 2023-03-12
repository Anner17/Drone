using Drones.Models;

namespace Drones.Repository
{
    public interface IDroneRepository
    {
        public Task RegisterDrone(Drone drone);
        public Task <List<Drone>>GetAvaliableDrones(string State);
        public Task <int>GetBateryByDroneNumber(int SerialNumberDrone);
    }
}
