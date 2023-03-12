using Drones.Models;

namespace Drones.Service
{
    public interface IDroneService
    {
        public Task RegisterDrone(Drone drone);
        public Task<List<Drone>> GetAvaliableDrones(string State);
        public Task<int> GetBateryByDroneNumber(int SerialNumberDrone);
    }
}
