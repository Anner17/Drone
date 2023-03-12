using Drones.Models;
using Drones.Service;
using Microsoft.AspNetCore.Mvc;

namespace Drones.Controllers
{
    [Route("[Controller]/[Action]")]
    
    public class DispatchController : ControllerBase
    {
        IDroneService DroneService = new DroneService();
        IMedicationService MedicationService = new MedicationService();

        [HttpPost]
        public async Task<IActionResult> RegisterDrone([FromBody]Drone drone)
        {
            try
            {
                await DroneService.RegisterDrone(drone);
                return Ok("Drone Registered");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> RegisterMedication([FromBody]Medication medication)
        {
            try
            {
                await MedicationService.RegisterMedication(medication);
                return Ok("Medication Registered");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetMedicationByDroneNumber(int SerialNumberDrone)
        {
            try
            {
                Medication medication = await MedicationService.GetMedicationByDroneNumber(SerialNumberDrone);
                return Ok(medication);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAvaliableDrones(string State)
        {
            try
            {
                List<Drone> drone = await DroneService.GetAvaliableDrones(State);
                return Ok(drone);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetBateryByDroneNumber(int SerialNumberDrone)
        {
            try
            {
                int Batery = await DroneService.GetBateryByDroneNumber(SerialNumberDrone);
                return Ok(Batery);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
