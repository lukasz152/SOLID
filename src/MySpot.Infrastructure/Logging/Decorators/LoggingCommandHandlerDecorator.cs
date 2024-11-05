using Humanizer;
using Microsoft.Extensions.Logging;
using MySpot.Application.Abstractions;
using System.Diagnostics;

namespace MySpot.Infrastructure.Logging.Decorators
{
    internal sealed class LoggingCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand>
     where TCommand : class, ICommand
    {
        private readonly ICommandHandler<TCommand> _commandHandler;
        private readonly ILogger<ICommandHandler<TCommand>> _logger;

        public LoggingCommandHandlerDecorator(ICommandHandler<TCommand> commandHandler,
            ILogger<ICommandHandler<TCommand>> logger)
        {
            _commandHandler = commandHandler;
            _logger = logger;
        }

        public async Task HandleAsync(TCommand command)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var commandName = typeof(TCommand).Name.Underscore;
            await _commandHandler.HandleAsync(command);
            stopWatch.Stop();
            _logger.LogInformation("Started handling a command : {CommandName} in {Elapsed}" , commandName,stopWatch.Elapsed);

        }
    }
}
