namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Represents a managed device in TeamViewer Remote Management.
/// </summary>
public class ManagedDevice
{
	/// <summary>
	/// Gets or sets the device ID.
	/// </summary>
	[JsonPropertyName("id")]
	public string? Id { get; set; }

	/// <summary>
	/// Gets or sets the device name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the TeamViewer ID.
	/// </summary>
	[JsonPropertyName("teamviewerid")]
	public string? TeamViewerId { get; set; }

	/// <summary>
	/// Gets or sets the online state.
	/// </summary>
	[JsonPropertyName("online_state")]
	public string? OnlineState { get; set; }

	/// <summary>
	/// Gets or sets the operating system.
	/// </summary>
	[JsonPropertyName("os")]
	public string? OperatingSystem { get; set; }

	/// <summary>
	/// Gets or sets the OS version.
	/// </summary>
	[JsonPropertyName("os_version")]
	public string? OsVersion { get; set; }

	/// <summary>
	/// Gets or sets the last seen timestamp.
	/// </summary>
	[JsonPropertyName("last_seen")]
	public DateTime? LastSeen { get; set; }

	/// <summary>
	/// Gets or sets the policy ID.
	/// </summary>
	[JsonPropertyName("policy_id")]
	public string? PolicyId { get; set; }

	/// <summary>
	/// Gets or sets the group ID.
	/// </summary>
	[JsonPropertyName("groupid")]
	public string? GroupId { get; set; }
}
