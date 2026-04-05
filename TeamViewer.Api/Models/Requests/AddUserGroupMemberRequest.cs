namespace TeamViewer.Api.Models.Requests;

/// <summary>
/// Request to add a member to a user group.
/// </summary>
public class AddUserGroupMemberRequest
{
	/// <summary>
	/// Gets or sets the account ID to add. Required.
	/// </summary>
	[JsonPropertyName("accountId")]
	public required int AccountId { get; set; }
}
