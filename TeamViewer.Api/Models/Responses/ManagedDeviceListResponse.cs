using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Response containing a list of managed devices.
/// </summary>
public class ManagedDeviceListResponse
{
	/// <summary>
	/// Gets or sets the list of managed devices.
	/// </summary>
	[JsonPropertyName("devices")]
	public List<ManagedDevice> Devices { get; set; } = [];
}
