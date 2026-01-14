using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Requests;

/// <summary>
/// Request to create a new group.
/// </summary>
public class CreateGroupRequest
{
	/// <summary>
	/// Gets or sets the group name. Required.
	/// </summary>
	[JsonPropertyName("name")]
	public required string Name { get; set; }

	/// <summary>
	/// Gets or sets the policy ID to associate with the group.
	/// </summary>
	[JsonPropertyName("policy_id")]
	public string? PolicyId { get; set; }
}
