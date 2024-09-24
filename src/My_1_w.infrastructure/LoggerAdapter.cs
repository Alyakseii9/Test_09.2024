using Microsoft.Extensions.Logging;
using My_1_w.Application.Core.Interfaces;
//using My_1_w.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_1_w.infrastructure
{
    public sealed class LoggerAdapter<T> : IAppLogger<T>
    {
        private readonly ILogger<T> _logger;

        public LoggerAdapter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<T>();
        }

        public void LogError(Exception exception, string? message, params object[] args)
        {
            _logger.LogError(exception, message, args);
        }

        public void LogInformation(string message, params object[] args)   
        {
           _logger.LogInformation(message, args);
        }

        public void LogWarning(string message, params object[] args)
        {
           _logger.LogWarning(message, args);
        }
    }
}
