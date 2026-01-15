namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Response containing a list of devices.
/// </summary>
public class DeviceListResponse
{
	/// <summary>
	/// Gets or sets the list of devices.
	/// </summary>
	[JsonPropertyName("devices")]
	public List<Device> Devices { get; set; } = [];
}
