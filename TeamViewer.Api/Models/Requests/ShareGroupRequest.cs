using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Requests;

/// <summary>
/// Request to share a group with users.
/// </summary>
public class ShareGroupRequest
{
	/// <summary>
	/// Gets or sets the list of users to share the group with.
	/// </summary>
	[JsonPropertyName("users")]
	public List<ShareGroupUser> Users { get; set; } = [];
}

/// <summary>
/// Represents a user to share a group with.
/// </summary>
public class ShareGroupUser
{
	/// <summary>
	/// Gets or sets the user ID to share with.
	/// </summary>
	[JsonPropertyName("userid")]
	public required string UserId { get; set; }

	/// <summary>
	/// Gets or sets the permissions to grant (e.g., "read", "readwrite", "full").
	/// </summary>
	[JsonPropertyName("permissions")]
	public required string Permissions { get; set; }
}
