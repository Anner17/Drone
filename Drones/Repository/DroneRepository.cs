using Dapper;
using Drones.Models;
using System.Data.SqlClient;


namespace Drones.Repository
{
    public class DroneRepository : IDroneRepository
    {
        string stringConnection = "Server=ANDREW\\SQLEXPRESS; Database=Drones; User Id=sa; Password=Password1;";
        public async Task RegisterDrone(Drone drone)
        {
            using (var Connection = new SqlConnection(stringConnection))
            {
                string Procedure = "[dbo].[RegisterDrone]";
                await Connection.ExecuteAsync(
                    Procedure,
                    new
                    {
                        drone.SerialNumberDrone,
                        drone.Model,
                        drone.WeightLimit,
                        drone.BateryCapacity,
                        drone.State
                    },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
        public async Task<List<Drone>> GetAvaliableDrones(string State)
        {
            var AvaliableDrones = new List<Drone>();
            using (var Connection = new SqlConnection(stringConnection))
            {
                string Procedure = "[dbo].[GetAvaliableDrones]";
                AvaliableDrones = (await Connection.QueryAsync<Drone>(
                    Procedure,
                    new
                    {
                        State,
                    },
                    commandType: System.Data.CommandType.StoredProcedure
                    )).ToList();                 
                return AvaliableDrones;
            }
        }
        public async Task<int> GetBateryByDroneNumber(int SerialNumberDrone)
        {
            using (var Connection = new SqlConnection(stringConnection))
            {
                string Procedure = "[dbo].[GetBateryByDroneNumber]";
                var Batery = await Connection.QueryFirstAsync<int>(
                    Procedure,
                    new
                    {
                        SerialNumberDrone,
                    },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
                return Batery;
            }
        }
        public async Task UpdateDrone(Drone drone)
        {
            using(var Connection = new SqlConnection(stringConnection))
            {
                string Procedure = "[dbo].[UpdateDrone]";
                await Connection.ExecuteAsync(
                    Procedure,
                    new
                    {
                        drone.SerialNumberDrone,
                        drone.Model,
                        drone.WeightLimit,
                        drone.BateryCapacity,
                        drone.State
                    },
                    commandType: System.Data.CommandType.StoredProcedure
                    ) ;
            }
        }

    }
}
