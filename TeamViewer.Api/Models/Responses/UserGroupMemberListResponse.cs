using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Response containing a list of user group members.
/// </summary>
public class UserGroupMemberListResponse
{
	/// <summary>
	/// Gets or sets the list of members.
	/// </summary>
	[JsonPropertyName("resources")]
	public List<UserGroupMember> Members { get; set; } = [];
}
