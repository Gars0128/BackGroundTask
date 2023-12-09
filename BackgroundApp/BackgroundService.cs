using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundTaskScheduler.Services
{
    public class BackgroundTaskService : BackgroundService
    {
        private readonly ILogger<BackgroundTaskService> _logger;
        private readonly int _interval;
        private readonly IConfiguration _configuration;

        public BackgroundTaskService(ILogger<BackgroundTaskService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _interval = _configuration.GetValue<int>("BackgroundTaskInterval");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Background task running at: {time}", DateTimeOffset.Now);
                try
                {
                    // execute task here
                    PerformBackgroundTask();

                    _logger.LogInformation("Background task completed at: {time}", DateTimeOffset.Now);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while executing the background task.");
                }

                await Task.Delay(_interval, stoppingToken);
            }
        }

        private void PerformBackgroundTask()
        {
            // simulate a task & generating random numbers
            Random random = new Random();
            int randomNumber = random.Next();
            _logger.LogInformation("Generated random number: {number}", randomNumber);
        }
    }
}
