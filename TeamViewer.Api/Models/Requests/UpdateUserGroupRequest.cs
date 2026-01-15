using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Requests;

/// <summary>
/// Request to update a user group.
/// </summary>
public class UpdateUserGroupRequest
{
	/// <summary>
	/// Gets or sets the group name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the group description.
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }
}
