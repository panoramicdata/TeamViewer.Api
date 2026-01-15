namespace TeamViewer.Api.Models.Requests;

/// <summary>
/// Request to update an existing device.
/// </summary>
public class UpdateDeviceRequest
{
	/// <summary>
	/// Gets or sets the device alias/name.
	/// </summary>
	[JsonPropertyName("alias")]
	public string? Alias { get; set; }

	/// <summary>
	/// Gets or sets the device description.
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// Gets or sets the group ID to move the device to.
	/// </summary>
	[JsonPropertyName("groupid")]
	public string? GroupId { get; set; }

	/// <summary>
	/// Gets or sets the password for the device.
	/// </summary>
	[JsonPropertyName("password")]
	public string? Password { get; set; }

	/// <summary>
	/// Gets or sets the policy ID to assign to the device.
	/// </summary>
	[JsonPropertyName("policy_id")]
	public string? PolicyId { get; set; }
}
