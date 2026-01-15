namespace TeamViewer.Api.Models.Requests;

/// <summary>
/// Request to add a hidden member to the address book.
/// </summary>
public class AddHiddenMemberRequest
{
	/// <summary>
	/// Gets or sets the account ID to hide. Required.
	/// </summary>
	[JsonPropertyName("accountId")]
	public required string AccountId { get; set; }
}
