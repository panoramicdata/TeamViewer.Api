namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Response containing a list of user roles.
/// </summary>
public class UserRoleListResponse
{
	/// <summary>
	/// Gets or sets the list of user roles.
	/// </summary>
	[JsonPropertyName("resources")]
	public List<UserRole> Roles { get; set; } = [];
}
