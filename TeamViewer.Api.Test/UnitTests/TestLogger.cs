using Microsoft.Extensions.Logging;

namespace TeamViewer.Api.Test.UnitTests;

/// <summary>
/// Test logger that captures log entries.
/// </summary>
internal class TestLogger<T> : TestLoggerBase, ILogger<T>
{
	public List<(LogLevel LogLevel, string Message)> LogEntries { get; } = [];

	/// <inheritdoc/>
	protected override void Write(LogLevel logLevel, string message, Exception? exception)
		=> LogEntries.Add((logLevel, message));
}
