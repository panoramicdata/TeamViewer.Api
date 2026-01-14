using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Requests;

/// <summary>
/// Request to add a device to a managed group.
/// </summary>
public class AddManagedDeviceRequest
{
	/// <summary>
	/// Gets or sets the device ID to add.
	/// </summary>
	[JsonPropertyName("deviceid")]
	public required string DeviceId { get; set; }
}
