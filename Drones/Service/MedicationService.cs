using Drones.Models;
using Drones.Repository;

namespace Drones.Service
{
    public class MedicationService : IMedicationService
    {
        IMedicationRepository MedicationRepository = new MedicationRepository();
        public async Task RegisterMedication(Medication medication)
        {
            await MedicationRepository.RegisterMedication(medication);
        }
        public async Task<Medication> GetMedicationByDroneNumber(int SerialNumberDrone)
        {
            return await MedicationRepository.GetMedicationByDroneNumber(SerialNumberDrone);
        }
    }
}
