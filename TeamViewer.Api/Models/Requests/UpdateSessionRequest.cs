namespace TeamViewer.Api.Models.Requests;

/// <summary>
/// Request to update an existing session code.
/// </summary>
public class UpdateSessionRequest
{
	/// <summary>
	/// Gets or sets the session state (e.g., "closed").
	/// </summary>
	[JsonPropertyName("state")]
	public string? State { get; set; }

	/// <summary>
	/// Gets or sets the session description.
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// Gets or sets the end customer name.
	/// </summary>
	[JsonPropertyName("end_customer")]
	public string? EndCustomer { get; set; }

	/// <summary>
	/// Gets or sets the waiting message for the customer.
	/// </summary>
	[JsonPropertyName("waiting_message")]
	public string? WaitingMessage { get; set; }

	/// <summary>
	/// Gets or sets the user ID to assign the session to.
	/// </summary>
	[JsonPropertyName("assigned_userid")]
	public string? AssignedUserId { get; set; }

	/// <summary>
	/// Gets or sets the group ID to move the session to.
	/// </summary>
	[JsonPropertyName("groupid")]
	public string? GroupId { get; set; }
}
