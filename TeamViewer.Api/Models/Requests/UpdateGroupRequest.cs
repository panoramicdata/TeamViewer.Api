namespace TeamViewer.Api.Models.Requests;

/// <summary>
/// Request to update an existing group.
/// </summary>
public class UpdateGroupRequest
{
	/// <summary>
	/// Gets or sets the group name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the policy ID to associate with the group.
	/// </summary>
	[JsonPropertyName("policy_id")]
	public string? PolicyId { get; set; }
}
