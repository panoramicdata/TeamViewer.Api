using Microsoft.Extensions.Logging;

namespace TeamViewer.Api.Test;

internal class XUnitLogger(ITestOutputHelper testOutputHelper) : ILogger
{
	public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;

	public bool IsEnabled(LogLevel logLevel) => true;

	public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
	{
		var message = formatter(state, exception);
		testOutputHelper.WriteLine($"[{logLevel}] {message}");
		if (exception is not null)
		{
			testOutputHelper.WriteLine(exception.ToString());
		}
	}
}
