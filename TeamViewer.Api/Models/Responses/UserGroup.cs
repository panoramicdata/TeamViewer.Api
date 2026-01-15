using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Represents a user group.
/// </summary>
public class UserGroup
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
	/// Gets or sets the group description.
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// Gets or sets the member count.
	/// </summary>
	[JsonPropertyName("member_count")]
	public int MemberCount { get; set; }
}
