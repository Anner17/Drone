using Dapper;
using Drones.Models;
using System.Data;
using System.Data.SqlClient;

namespace Drones.Repository
{
    public class MedicationRepository: IMedicationRepository
    {
        string stringConnection = "Server=ANDREW\\SQLEXPRESS; Database=Drones; User Id=sa; Password=Password1;";
        public async Task RegisterMedication(Medication medication)
        {
            using (var Connection = new SqlConnection(stringConnection))
            {
                string Procedure = "[dbo].[RegisterMedication]";
                await Connection.ExecuteAsync(
                    Procedure,
                    new
                    {
                        medication.Name,
                        medication.Weight,
                        medication.MedicationCode,
                        medication.Image,
                        medication.SerialNumberDrone
                    },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
        public async Task<Medication> GetMedicationByDroneNumber(int SerialNumberDrone)
        {
            using (var Connection = new SqlConnection(stringConnection))
            {
                string Procedure = "[dbo].[GetMedicationByDroneNumber]";
                var medicationByID = await Connection.QueryFirstAsync<Medication>(
                    Procedure,
                    new
                    {
                        SerialNumberDrone
                    },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
                return medicationByID;
            }
            
        }
    }
}
