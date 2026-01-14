using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Response containing a list of users a group is shared with.
/// </summary>
public class GroupShareListResponse
{
	/// <summary>
	/// Gets or sets the list of shared users.
	/// </summary>
	[JsonPropertyName("shared_with")]
	public List<GroupShare> SharedWith { get; set; } = [];
}

/// <summary>
/// Represents a user that a group is shared with.
/// </summary>
public class GroupShare
{
	/// <summary>
	/// Gets or sets the user ID.
	/// </summary>
	[JsonPropertyName("userid")]
	public string? UserId { get; set; }

	/// <summary>
	/// Gets or sets the user's name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the permissions granted to the user.
	/// </summary>
	[JsonPropertyName("permissions")]
	public string? Permissions { get; set; }
}
