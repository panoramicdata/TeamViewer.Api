namespace TeamViewer.Api;

/// <summary>
/// Configuration options for the TeamViewer API client.
/// </summary>
public class TeamViewerClientOptions
{
	/// <summary>
	/// Gets or sets the TeamViewer script token for authentication.
	/// </summary>
	public required string ScriptToken { get; set; }

	/// <summary>
	/// Gets or sets the base URL for the TeamViewer API.
	/// </summary>
	public string BaseUrl { get; set; } = "https://webapi.teamviewer.com/api/v1/";

	/// <summary>
	/// Gets or sets the maximum number of retry attempts for failed requests.
	/// </summary>
	public int MaxRetryAttempts { get; set; } = 3;

	/// <summary>
	/// Gets or sets the initial delay in milliseconds between retry attempts.
	/// </summary>
	public int RetryDelayMilliseconds { get; set; } = 1000;

	/// <summary>
	/// Gets or sets the HTTP request timeout.
	/// </summary>
	public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(30);
}
