namespace TeamViewer.Api.Models.Requests;

/// <summary>
/// Request to invite a contact by email.
/// </summary>
public class InviteContactRequest
{
	/// <summary>
	/// Gets or sets the email address to invite. Required.
	/// </summary>
	[JsonPropertyName("email")]
	public required string Email { get; set; }

	/// <summary>
	/// Gets or sets the group ID to add the contact to.
	/// </summary>
	[JsonPropertyName("groupid")]
	public string? GroupId { get; set; }
}
