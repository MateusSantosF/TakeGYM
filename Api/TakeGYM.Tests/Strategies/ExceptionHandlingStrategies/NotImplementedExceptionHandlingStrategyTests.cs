using System.Threading.Tasks;

using TakeGYM.Facades.Strategies.ExceptionHandlingStrategies;
using TakeGYM.Tests.Setup.Controller;

using Microsoft.AspNetCore.Http;

using NSubstitute;

using Serilog;

using Shouldly;

using Xunit;

namespace TakeGYM.Tests.Strategies.ExceptionHandlingStrategies
{
    public class NotImplementedExceptionHandlingStrategyTests
    {
        private readonly ILogger _logger;

        public NotImplementedExceptionHandlingStrategyTests()
        {
            _logger = Substitute.For<ILogger>();
        }

        private NotImplementedExceptionHandlingStrategy CreateNotImplementedExceptionHandlingStrategy()
        {
            return new NotImplementedExceptionHandlingStrategy(_logger);
        }

        [Fact]
        public async Task HandleAsyncExpectedBehaviorAsync()
        {
            var notImplementedExceptionHandlingStrategy = CreateNotImplementedExceptionHandlingStrategy();

            var context = ControllerSetup.HttpContext;
            var exception = ControllerSetup.NotImplementedException;

            var result = await notImplementedExceptionHandlingStrategy.HandleAsync(
                context,
                exception);

            result.Response.StatusCode.ShouldBe(StatusCodes.Status501NotImplemented);
        }
    }
}
