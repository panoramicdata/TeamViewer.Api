using Microsoft.Extensions.Logging;

namespace TeamViewer.Api.Test;

/// <summary>
/// Base for the test loggers. <see cref="ILogger"/>'s scope, level and message-formatting plumbing is
/// the same for all of them, so a derived logger only decides what to do with the formatted message.
/// </summary>
internal abstract class TestLoggerBase : ILogger
{
	/// <inheritdoc/>
	public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;

	/// <inheritdoc/>
	public bool IsEnabled(LogLevel logLevel) => true;

	/// <inheritdoc/>
	public void Log<TState>(
		LogLevel logLevel,
		EventId eventId,
		TState state,
		Exception? exception,
		Func<TState, Exception?, string> formatter)
		=> Write(logLevel, formatter(state, exception), exception);

	/// <summary>
	/// Handles one formatted log entry.
	/// </summary>
	protected abstract void Write(LogLevel logLevel, string message, Exception? exception);
}
