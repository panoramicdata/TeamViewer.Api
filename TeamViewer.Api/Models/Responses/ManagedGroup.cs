using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Represents a managed group in TeamViewer Remote Management.
/// </summary>
public class ManagedGroup
{
	/// <summary>
	/// Gets or sets the group ID.
	/// </summary>
	[JsonPropertyName("id")]
	public string? Id { get; set; }

	/// <summary>
	/// Gets or sets the group name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the policy ID.
	/// </summary>
	[JsonPropertyName("policy_id")]
	public string? PolicyId { get; set; }

	/// <summary>
	/// Gets or sets the number of devices in the group.
	/// </summary>
	[JsonPropertyName("device_count")]
	public int DeviceCount { get; set; }
}
