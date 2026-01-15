namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Represents an endpoint with protection status.
/// </summary>
public class ProtectedEndpoint
{
	/// <summary>
	/// Gets or sets the device ID.
	/// </summary>
	[JsonPropertyName("deviceId")]
	public string? DeviceId { get; set; }

	/// <summary>
	/// Gets or sets the device name.
	/// </summary>
	[JsonPropertyName("deviceName")]
	public string? DeviceName { get; set; }

	/// <summary>
	/// Gets or sets the protection status.
	/// </summary>
	[JsonPropertyName("protectionStatus")]
	public string? ProtectionStatus { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether protection is enabled.
	/// </summary>
	[JsonPropertyName("protectionEnabled")]
	public bool ProtectionEnabled { get; set; }

	/// <summary>
	/// Gets or sets the last scan date.
	/// </summary>
	[JsonPropertyName("lastScanDate")]
	public DateTime? LastScanDate { get; set; }

	/// <summary>
	/// Gets or sets the threat count.
	/// </summary>
	[JsonPropertyName("threatCount")]
	public int ThreatCount { get; set; }
}

/// <summary>
/// Response containing a list of protected endpoints.
/// </summary>
public class EndpointProtectionListResponse
{
	/// <summary>
	/// Gets or sets the list of endpoints.
	/// </summary>
	[JsonPropertyName("endpoints")]
	public List<ProtectedEndpoint> Endpoints { get; set; } = [];
}
