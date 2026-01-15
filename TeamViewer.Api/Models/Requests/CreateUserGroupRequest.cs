namespace TeamViewer.Api.Models.Requests;

/// <summary>
/// Request to create a user group.
/// </summary>
public class CreateUserGroupRequest
{
	/// <summary>
	/// Gets or sets the group name. Required.
	/// </summary>
	[JsonPropertyName("name")]
	public required string Name { get; set; }

	/// <summary>
	/// Gets or sets the group description.
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }
}
