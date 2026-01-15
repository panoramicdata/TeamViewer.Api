namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Represents a TeamViewer session code.
/// </summary>
public class Session
{
	/// <summary>
	/// Gets or sets the session code (prefixed with 's').
	/// </summary>
	[JsonPropertyName("code")]
	public string? Code { get; set; }

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
	/// Gets or sets the group ID this session belongs to.
	/// </summary>
	[JsonPropertyName("groupid")]
	public string? GroupId { get; set; }

	/// <summary>
	/// Gets or sets the group name this session belongs to.
	/// </summary>
	[JsonPropertyName("groupname")]
	public string? GroupName { get; set; }

	/// <summary>
	/// Gets or sets the session state (e.g., "open", "waiting", "closed").
	/// </summary>
	[JsonPropertyName("state")]
	public string? State { get; set; }

	/// <summary>
	/// Gets or sets the waiting message displayed to the customer.
	/// </summary>
	[JsonPropertyName("waiting_message")]
	public string? WaitingMessage { get; set; }

	/// <summary>
	/// Gets or sets the assigned user ID.
	/// </summary>
	[JsonPropertyName("assigned_userid")]
	public string? AssignedUserId { get; set; }

	/// <summary>
	/// Gets or sets the supporter link for the session.
	/// </summary>
	[JsonPropertyName("supporter_link")]
	public string? SupporterLink { get; set; }

	/// <summary>
	/// Gets or sets the end customer link for the session.
	/// </summary>
	[JsonPropertyName("end_customer_link")]
	public string? EndCustomerLink { get; set; }

	/// <summary>
	/// Gets or sets the creation time.
	/// </summary>
	[JsonPropertyName("created_at")]
	public DateTime? CreatedAt { get; set; }

	/// <summary>
	/// Gets or sets the valid until time.
	/// </summary>
	[JsonPropertyName("valid_until")]
	public DateTime? ValidUntil { get; set; }
}
