using Drones.Models;

namespace Drones.Service
{
    public interface IMedicationService
    {
        public Task RegisterMedication(Medication medication);
        public Task<Medication> GetMedicationByDroneNumber(int SerialNumberDrone);
    }
}
