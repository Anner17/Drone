namespace Drones.Models
{
    public class Drone
    {
        public int SerialNumberDrone { get; set; }
        public string Model { get; set; }
        public int WeightLimit { get; set; }
        public int BateryCapacity { get; set; }
        public string State { get; set; }

    }
}
