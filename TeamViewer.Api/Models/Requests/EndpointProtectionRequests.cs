using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Requests;

/// <summary>
/// Request to install endpoint protection on devices.
/// </summary>
public class InstallEndpointProtectionRequest
{
	/// <summary>
	/// Gets or sets the device IDs to install protection on. Required.
	/// </summary>
	[JsonPropertyName("deviceIds")]
	public required List<string> DeviceIds { get; set; }
}

/// <summary>
/// Request to link devices to endpoint protection.
/// </summary>
public class LinkDevicesRequest
{
	/// <summary>
	/// Gets or sets the device IDs to link. Required.
	/// </summary>
	[JsonPropertyName("deviceIds")]
	public required List<string> DeviceIds { get; set; }
}
