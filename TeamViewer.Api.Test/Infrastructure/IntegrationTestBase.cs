namespace TeamViewer.Api.Test.Infrastructure;

/// <summary>
/// Base class for integration tests.
/// </summary>
public abstract class IntegrationTestBase : IDisposable
{
	private bool _disposed;

	/// <summary>
	/// Gets the TeamViewer client for testing.
	/// </summary>
	protected TeamViewerClient? Client { get; }

	/// <summary>
	/// Gets the test configuration.
	/// </summary>
	protected TestConfig Config { get; }

	/// <summary>
	/// Gets a value indicating whether this test should be skipped.
	/// </summary>
	protected string? SkipReason { get; }

	/// <summary>
	/// Initializes a new instance of the <see cref="IntegrationTestBase"/> class.
	/// </summary>
	protected IntegrationTestBase()
	{
		Config = TestConfig.Instance;

		if (!Config.IsConfigured)
		{
			SkipReason = "TeamViewer API credentials not configured. Add ScriptToken to user secrets.";
			return;
		}

		var options = new TeamViewerClientOptions
		{
			ScriptToken = Config.ScriptToken
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
