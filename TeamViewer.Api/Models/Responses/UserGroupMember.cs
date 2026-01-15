namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Represents a user group member.
/// </summary>
public class UserGroupMember
{
	/// <summary>
	/// Gets or sets the account ID.
	/// </summary>
	[JsonPropertyName("accountId")]
	public string? AccountId { get; set; }

	/// <summary>
	/// Gets or sets the member name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the member email.
	/// </summary>
	[JsonPropertyName("email")]
	public string? Email { get; set; }
}
