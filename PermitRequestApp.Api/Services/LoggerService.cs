using Microsoft.Extensions.Logging;
using PermitRequestApp.Api.Services.Contracts;

namespace PermitRequestApp.Api.Services
{
    public class LoggerService<TObject> : ILoggerService<TObject> where TObject: class
    {
        private readonly ILogger<TObject> _logger;
        public LoggerService(ILogger<TObject> logger) => _logger = logger;
        public void LogError(string message, params object[] args) => _logger.LogError(message, args);
        public void LogInformation(string message, params object[] args) => _logger.LogInformation(message, args);
    }
}
