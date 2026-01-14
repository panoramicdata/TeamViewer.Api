using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Requests;

/// <summary>
/// Request to create a new meeting.
/// </summary>
public class CreateMeetingRequest
{
	/// <summary>
	/// Gets or sets the meeting subject. Required.
	/// </summary>
	[JsonPropertyName("subject")]
	public required string Subject { get; set; }

	/// <summary>
	/// Gets or sets the start date/time.
	/// </summary>
	[JsonPropertyName("start")]
	public DateTime? Start { get; set; }

	/// <summary>
	/// Gets or sets the end date/time.
	/// </summary>
	[JsonPropertyName("end")]
	public DateTime? End { get; set; }

	/// <summary>
	/// Gets or sets the meeting password.
	/// </summary>
	[JsonPropertyName("password")]
	public string? Password { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether this is a recurring meeting.
	/// </summary>
	[JsonPropertyName("recurring")]
	public bool? Recurring { get; set; }

	/// <summary>
	/// Gets or sets the recurrence type (daily, weekly, monthly).
	/// </summary>
	[JsonPropertyName("recurrence_type")]
	public string? RecurrenceType { get; set; }

	/// <summary>
	/// Gets or sets the recurrence end date.
	/// </summary>
	[JsonPropertyName("recurrence_enddate")]
	public DateTime? RecurrenceEndDate { get; set; }
}
