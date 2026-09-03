using Microsoft.Extensions.Logging;

namespace TeamViewer.Api.Test;

/// <summary>
/// Test logger that writes log entries to the xUnit test output.
/// </summary>
internal class XUnitLogger(ITestOutputHelper testOutputHelper) : TestLoggerBase
{
	/// <inheritdoc/>
	protected override void Write(LogLevel logLevel, string message, Exception? exception)
	{
		testOutputHelper.WriteLine($"[{logLevel}] {message}");
		if (exception is not null)
		{
			testOutputHelper.WriteLine(exception.ToString());
		}
	}
}
