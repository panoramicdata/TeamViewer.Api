namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Response containing a list of user groups.
/// </summary>
public class UserGroupListResponse
{
	/// <summary>
	/// Gets or sets the list of user groups.
	/// </summary>
	[JsonPropertyName("resources")]
	public List<UserGroup> Groups { get; set; } = [];
}
