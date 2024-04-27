using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace Crosscuting.Base.Behaviours
{
    public class RequestPerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly Stopwatch _timer;
        private readonly ILogger<TRequest> _logger;

        public RequestPerformanceBehaviour(ILogger<TRequest> logger)
        {
            _logger = logger;
            _timer = new Stopwatch();
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _timer.Start();
            var response = await next();

            _timer.Stop();
            var elapsedTime = _timer.Elapsed;

            if(elapsedTime.Seconds > 5)
            {
                _logger.LogWarning("[PERFORMANCE] Long Running Request: {Name} took {TimeTaken} seconds",
                    typeof(TRequest).Name, elapsedTime.Seconds);
            }

            return response;
        }
    }
}
