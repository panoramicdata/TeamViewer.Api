namespace TeamViewer.Api.Models.Requests;

/// <summary>
/// Request parameters for getting users.
/// </summary>
public class GetUsersRequest
{
	/// <summary>
	/// Gets or sets the name filter.
	/// </summary>
	[AliasAs("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the email filter.
	/// </summary>
	[AliasAs("email")]
	public string? Email { get; set; }

	/// <summary>
	/// Gets or sets the permissions filter.
	/// </summary>
	[AliasAs("permissions")]
	public string? Permissions { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether to return full user details including permissions.
	/// </summary>
	[AliasAs("full_list")]
	public bool? Full { get; set; }
}
