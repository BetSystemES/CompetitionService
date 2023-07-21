using CompetitionService.Grpc.Extensions;
using CompetitionService.Grpc.Interceptors.Models;
using FluentValidation;
using Grpc.Core;
using Newtonsoft.Json;

namespace CompetitionService.Grpc.Interceptors.Helpers
{
    public static class ExceptionHelpers
    {
        public static RpcException Handle<T>(this Exception exception, ServerCallContext context, ILogger<T> logger)
        {
            return exception switch
            {
                TimeoutException => HandleDefault(exception, context, logger, StatusCode.DeadlineExceeded),
                ValidationException => HandleValidationException((ValidationException)exception, logger),
                _ => HandleDefault(exception, context, logger)
            };
        }

        private static RpcException HandleValidationException<T>(ValidationException exception, ILogger<T> logger)
        {
            logger.LogError(exception, $"An ValidationException occurred");

            var details = exception.Errors.Select(x => new GrpcExceptionDetail(x.PropertyName, x.ErrorMessage));
            var statusMessage = new StatusMessage(typeof(ValidationException).Name, details);

            var exeptionMessageString = JsonConvert.SerializeObject(statusMessage, Formatting.Indented);

            var status = new Status(StatusCode.InvalidArgument, exeptionMessageString);

            return new RpcException(status);
        }

        private static RpcException HandleDefault<T>(Exception exception,
            ServerCallContext context,
            ILogger<T> logger,
            StatusCode statusCode = StatusCode.Internal)
        {
            var exceptionName = exception.GetType().Name;

            var exceptionMessage = exception.GetAllExceptionMessages();

            logger.LogError(exception, $"An {exceptionName} occurred, with message={exceptionMessage}");

            var statusMessage = new StatusMessage(exceptionName,
            new List<GrpcExceptionDetail>()
            {
                new(exceptionMessage)
            });

            var exceptionMessageString = JsonConvert.SerializeObject(statusMessage, Formatting.Indented);
            var status = new Status(statusCode, exceptionMessageString);

            return new RpcException(status);
        }
    }
}
