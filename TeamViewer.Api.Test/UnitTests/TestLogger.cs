using Microsoft.Extensions.Logging;

namespace TeamViewer.Api.Test.UnitTests;

/// <summary>
/// Test logger that captures log entries.
/// </summary>
internal class TestLogger<T> : ILogger<T>
{
	public List<(LogLevel LogLevel, string Message)> LogEntries { get; } = [];

	public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;

	public bool IsEnabled(LogLevel logLevel) => true;

	public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
	{
		LogEntries.Add((logLevel, formatter(state, exception)));
	}
}
