using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace LoggingLibSample
{
    public class CarsContext : IDisposable
    {
        private readonly ILogger _logger;

        public CarsContext(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<CarsContext>();
            _logger.LogDebug("Constructing CarsContext");
        }

        public IEnumerable<string> GetCars()
        {
            _logger.LogInformation("Found 3 cars.");

            return new[]
            {
                "Car 1",
                "Car 2",
                "Car 3"
            };
        }

        public void Dispose()
        {
            _logger.LogDebug("Disposing CarsContext");
        }
    }
}