using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Response containing a list of users.
/// </summary>
public class UserListResponse
{
	/// <summary>
	/// Gets or sets the list of users.
	/// </summary>
	[JsonPropertyName("users")]
	public List<User> Users { get; set; } = [];
}
