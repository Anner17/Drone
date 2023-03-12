using Microsoft.Extensions.Hosting;

namespace Drones.BateryChecker
{
    public class PeriodicHostedService : BackgroundService
    {
        private readonly TimeSpan _period = TimeSpan.FromSeconds(5);
        private readonly ILogger<PeriodicHostedService> _logger;
        private readonly IServiceScopeFactory _factory;
        private int _executionCount = 0;
        public PeriodicHostedService(ILogger<PeriodicHostedService> logger, IServiceScopeFactory factory) {
            _logger = logger;
            _factory = factory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using PeriodicTimer timer = new PeriodicTimer(_period);
            while (
                !stoppingToken.IsCancellationRequested &&
                await timer.WaitForNextTickAsync(stoppingToken))
            {
                try
                {
                    await using AsyncServiceScope asyncScope = _factory.CreateAsyncScope();
                    BatteryCheckerService batteryCheckerService = asyncScope.ServiceProvider.GetRequiredService<BatteryCheckerService>();
                    await batteryCheckerService.CheckBatteries();
                    _executionCount++;
                    _logger.LogInformation(
                        $"Executed PeriodicHostedService - Count: {_executionCount}");
                    
                }
                catch (Exception ex)
                {
                    _logger.LogInformation(
                        $"Failed to execute PeriodicHostedService with exception message {ex.Message}. Good luck next round!");
                }
            }
        }
    }
    
}
