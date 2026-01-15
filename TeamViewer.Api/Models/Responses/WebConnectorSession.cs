namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Represents a WebConnector session.
/// </summary>
public class WebConnectorSession
{
	/// <summary>
	/// Gets or sets the session ID.
	/// </summary>
	[JsonPropertyName("session_id")]
	public string? SessionId { get; set; }

	/// <summary>
	/// Gets or sets the session code.
	/// </summary>
	[JsonPropertyName("code")]
	public string? Code { get; set; }

	/// <summary>
	/// Gets or sets the session URL.
	/// </summary>
	[JsonPropertyName("url")]
	public string? Url { get; set; }

	/// <summary>
	/// Gets or sets the device ID.
	/// </summary>
	[JsonPropertyName("device_id")]
	public string? DeviceId { get; set; }

	/// <summary>
	/// Gets or sets the session state.
	/// </summary>
	[JsonPropertyName("state")]
	public string? State { get; set; }

	/// <summary>
	/// Gets or sets the creation timestamp.
	/// </summary>
	[JsonPropertyName("created_at")]
	public DateTime? CreatedAt { get; set; }

	/// <summary>
	/// Gets or sets the expiration timestamp.
	/// </summary>
	[JsonPropertyName("expires_at")]
	public DateTime? ExpiresAt { get; set; }
}
