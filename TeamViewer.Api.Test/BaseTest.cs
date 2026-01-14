using Microsoft.Extensions.Logging;
using TeamViewer.Api.Test.Infrastructure;

namespace TeamViewer.Api.Test;

/// <summary>
/// Base class for testing.
/// </summary>
public abstract class BaseTest : IDisposable
{
	private bool _disposed;

	/// <summary>
	/// Gets the TeamViewer client for testing.
	/// </summary>
	protected TeamViewerClient Client { get; }

	/// <summary>
	/// Gets the test configuration.
	/// </summary>
	protected TestConfig Config { get; }

	/// <summary>
	/// Gets the test prefix for created resources.
	/// </summary>
	protected string TestPrefix => Config.TestPrefix;

	/// <summary>
	/// Gets a value indicating whether this test should be skipped.
	/// </summary>
	protected string? SkipReason { get; }

	/// <summary>
	/// Gets the <see cref="CancellationToken"/> associated with the current test context.
	/// </summary>
	/// <remarks>Use this token to observe cancellation requests for operations that should be responsive to test
	/// cancellation. The token reflects the cancellation state of the current test execution and can be passed to
	/// asynchronous methods or long-running operations to enable cooperative cancellation.</remarks>
	protected static CancellationToken CancellationToken => TestContext.Current.CancellationToken;

	protected ILogger Logger { get; }

	/// <summary>
	/// Initializes a new instance of the <see cref="BaseTest"/> class.
	/// </summary>
	protected BaseTest(ITestOutputHelper testOutputHelper)
	{
		Config = TestConfig.Instance;

		Logger = new XUnitLogger(testOutputHelper);

		if (!Config.IsConfigured)
		{
			SkipReason = "TeamViewer API credentials not configured. Add ScriptToken to user secrets.";
			throw new InvalidOperationException(SkipReason);
		}

		var options = new TeamViewerClientOptions
		{
			ScriptToken = Config.ScriptToken,
			Logger = Logger,
		};
		Client = new TeamViewerClient(options);
	}

	/// <summary>
	/// Ensures the test should run, throws Skip if not configured.
	/// </summary>
	protected void EnsureConfigured()
	{
		if (SkipReason is not null)
			Assert.Skip(SkipReason);
	}

	/// <inheritdoc/>
	public void Dispose()
	{
		if (_disposed)
			return;

		Client?.Dispose();
		_disposed = true;
		GC.SuppressFinalize(this);
	}
}
