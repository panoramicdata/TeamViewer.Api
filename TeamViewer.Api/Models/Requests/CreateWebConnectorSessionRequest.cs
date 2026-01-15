using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Requests;

/// <summary>
/// Request to create a WebConnector session.
/// </summary>
public class CreateWebConnectorSessionRequest
{
	/// <summary>
	/// Gets or sets the device ID to connect to. Required.
	/// </summary>
	[JsonPropertyName("device_id")]
	public required string DeviceId { get; set; }

	/// <summary>
	/// Gets or sets the session password.
	/// </summary>
	[JsonPropertyName("password")]
	public string? Password { get; set; }

	/// <summary>
	/// Gets or sets the connection mode.
	/// </summary>
	[JsonPropertyName("mode")]
	public string? Mode { get; set; }
}
