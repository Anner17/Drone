using Drones.Models;

namespace Drones.Repository
{
    public interface IMedicationRepository
    {
        public Task RegisterMedication(Medication medication);
        public Task<Medication> GetMedicationByDroneNumber(int SerialNumberDrone);
    }
}
