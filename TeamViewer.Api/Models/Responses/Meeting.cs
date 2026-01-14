using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Represents a TeamViewer meeting.
/// </summary>
public class Meeting
{
	/// <summary>
	/// Gets or sets the meeting ID (prefixed with 'm').
	/// </summary>
	[JsonPropertyName("meeting_id")]
	public string? MeetingId { get; set; }

	/// <summary>
	/// Gets or sets the meeting subject.
	/// </summary>
	[JsonPropertyName("subject")]
	public string? Subject { get; set; }

	/// <summary>
	/// Gets or sets the start date/time of the meeting.
	/// </summary>
	[JsonPropertyName("start")]
	public DateTime? Start { get; set; }

	/// <summary>
	/// Gets or sets the end date/time of the meeting.
	/// </summary>
	[JsonPropertyName("end")]
	public DateTime? End { get; set; }

	/// <summary>
	/// Gets or sets the meeting owner user ID.
	/// </summary>
	[JsonPropertyName("ownerid")]
	public string? OwnerId { get; set; }

	/// <summary>
	/// Gets or sets the meeting state (e.g., "scheduled", "running", "ended").
	/// </summary>
	[JsonPropertyName("state")]
	public string? State { get; set; }

	/// <summary>
	/// Gets or sets the meeting password.
	/// </summary>
	[JsonPropertyName("password")]
	public string? Password { get; set; }

	/// <summary>
	/// Gets or sets the participant link URL.
	/// </summary>
	[JsonPropertyName("participant_link")]
	public string? ParticipantLink { get; set; }

	/// <summary>
	/// Gets or sets the organizer link URL.
	/// </summary>
	[JsonPropertyName("organizer_link")]
	public string? OrganizerLink { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether this is a recurring meeting.
	/// </summary>
	[JsonPropertyName("recurring")]
	public bool Recurring { get; set; }

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
