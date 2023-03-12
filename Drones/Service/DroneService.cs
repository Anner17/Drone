using Drones.Models;
using Drones.Repository;

namespace Drones.Service
{    
    public class DroneService: IDroneService
    {
        IDroneRepository droneRepository = new DroneRepository();
        public async Task RegisterDrone(Drone drone)
        {
            await droneRepository.RegisterDrone(drone);
        }
        public async Task<List<Drone>> GetAvaliableDrones(string State)
        {
            return await droneRepository.GetAvaliableDrones(State);
        }
        public async Task<int> GetBateryByDroneNumber(int SerialNumberDrone)
        {
            return await droneRepository.GetBateryByDroneNumber(SerialNumberDrone);
        }
    }
}
