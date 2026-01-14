using Microsoft.Extensions.Configuration;

namespace TeamViewer.Api.Test.Infrastructure;

/// <summary>
/// Configuration for integration tests.
/// </summary>
public class TestConfig
{
	private static readonly Lazy<TestConfig> _instance = new(() => LoadConfig());

	/// <summary>
	/// Gets the singleton instance.
	/// </summary>
	public static TestConfig Instance => _instance.Value;

	/// <summary>
	/// Gets the TeamViewer script token.
	/// </summary>
	public string ScriptToken { get; private set; } = string.Empty;

	/// <summary>
	/// Gets a value indicating whether tests can run.
	/// </summary>
	public bool IsConfigured => !string.IsNullOrEmpty(ScriptToken);

	private static TestConfig LoadConfig()
	{
		var config = new ConfigurationBuilder()
			.AddJsonFile("secrets.example.json", optional: true)
			.AddUserSecrets<TestConfig>(optional: true)
			.AddEnvironmentVariables()
			.Build();

		return new TestConfig
		{
			ScriptToken = config["TeamViewer:ScriptToken"] ?? string.Empty
		};
	}
}
