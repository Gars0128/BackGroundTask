using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace BackgroundTaskScheduler.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SampleController : ControllerBase
    {
        private readonly ILogger<SampleController> _logger;
        private readonly IConfiguration _configuration;

        public SampleController(ILogger<SampleController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet("start-background-task")]
        public IActionResult StartBackgroundTask()
        {
            // You can trigger the background task from here if needed
            _logger.LogInformation("API endpoint called to start the background task.");
            // Trigger the background task logic here if required

            return Ok("Background task started.");
        }

        [HttpGet("configure-interval/{interval}")]
        public IActionResult ConfigureInterval(int interval)
        {
            // Example endpoint to configure the background task interval dynamically
            _configuration["BackgroundTaskInterval"] = interval.ToString();
            _logger.LogInformation("Background task interval updated to: {interval} milliseconds.", interval);

            return Ok($"Background task interval updated to: {interval} milliseconds.");
        }
    }
}

