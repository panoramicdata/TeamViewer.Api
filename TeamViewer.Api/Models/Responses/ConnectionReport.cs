namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Represents a connection report entry.
/// </summary>
public class ConnectionReport
{
	/// <summary>
	/// Gets or sets the report ID.
	/// </summary>
	[JsonPropertyName("id")]
	public string? Id { get; set; }

	/// <summary>
	/// Gets or sets the user ID who made the connection.
	/// </summary>
	[JsonPropertyName("userid")]
	public string? UserId { get; set; }

	/// <summary>
	/// Gets or sets the user name who made the connection.
	/// </summary>
	[JsonPropertyName("username")]
	public string? UserName { get; set; }

	/// <summary>
	/// Gets or sets the device ID that was connected to.
	/// </summary>
	[JsonPropertyName("deviceid")]
	public string? DeviceId { get; set; }

	/// <summary>
	/// Gets or sets the device name that was connected to.
	/// </summary>
	[JsonPropertyName("devicename")]
	public string? DeviceName { get; set; }

	/// <summary>
	/// Gets or sets the group ID.
	/// </summary>
	[JsonPropertyName("groupid")]
	public string? GroupId { get; set; }

	/// <summary>
	/// Gets or sets the group name.
	/// </summary>
	[JsonPropertyName("groupname")]
	public string? GroupName { get; set; }

	/// <summary>
	/// Gets or sets the start date/time of the connection.
	/// </summary>
	[JsonPropertyName("start_date")]
	public DateTime? StartDate { get; set; }

	/// <summary>
	/// Gets or sets the end date/time of the connection.
	/// </summary>
	[JsonPropertyName("end_date")]
	public DateTime? EndDate { get; set; }

	/// <summary>
	/// Gets or sets the session duration in seconds.
	/// </summary>
	[JsonPropertyName("duration")]
	public int? Duration { get; set; }

	/// <summary>
	/// Gets or sets the session notes/comments.
	/// </summary>
	[JsonPropertyName("notes")]
	public string? Notes { get; set; }

	/// <summary>
	/// Gets or sets the billing state.
	/// </summary>
	[JsonPropertyName("billing_state")]
	public string? BillingState { get; set; }

	/// <summary>
	/// Gets or sets the currency for billing.
	/// </summary>
	[JsonPropertyName("currency")]
	public string? Currency { get; set; }

	/// <summary>
	/// Gets or sets the fee charged.
	/// </summary>
	[JsonPropertyName("fee")]
	public decimal? Fee { get; set; }

	/// <summary>
	/// Gets or sets the support session type.
	/// </summary>
	[JsonPropertyName("support_session_type")]
	public string? SupportSessionType { get; set; }
}
