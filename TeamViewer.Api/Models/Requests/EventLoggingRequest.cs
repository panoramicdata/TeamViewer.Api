namespace TeamViewer.Api.Models.Requests;

/// <summary>
/// Request for retrieving audit events.
/// </summary>
public class EventLoggingRequest
{
	/// <summary>
	/// Gets or sets the start date for the event query (ISO 8601 format).
	/// </summary>
	[JsonPropertyName("StartDate")]
	public string? StartDate { get; set; }

	/// <summary>
	/// Gets or sets the end date for the event query (ISO 8601 format).
	/// </summary>
	[JsonPropertyName("EndDate")]
	public string? EndDate { get; set; }

	/// <summary>
	/// Gets or sets the event types to filter by.
	/// </summary>
	[JsonPropertyName("EventTypes")]
	public List<string>? EventTypes { get; set; }

	/// <summary>
	/// Gets or sets the user IDs to filter by.
	/// </summary>
	[JsonPropertyName("UserIds")]
	public List<string>? UserIds { get; set; }

	/// <summary>
	/// Gets or sets the account name filter.
	/// </summary>
	[JsonPropertyName("AccountName")]
	public string? AccountName { get; set; }

	/// <summary>
	/// Gets or sets the continuation token for pagination.
	/// </summary>
	[JsonPropertyName("ContinuationToken")]
	public string? ContinuationToken { get; set; }

	/// <summary>
	/// Gets or sets the maximum number of results to return.
	/// </summary>
	[JsonPropertyName("Limit")]
	public int? Limit { get; set; }
}
