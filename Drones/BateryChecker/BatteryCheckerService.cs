namespace Drones.BateryChecker
{
    public class BatteryCheckerService
    {
        private readonly ILogger<BatteryCheckerService> _logger;
        private int i = 1;
        public BatteryCheckerService(ILogger<BatteryCheckerService> logger)
        {
            _logger = logger;
        }

        public async Task CheckBatteries()
        {
            await Task.Delay(100);
            _logger.LogInformation(
                "Sample Service did something. " + i);
        }
    }
}
