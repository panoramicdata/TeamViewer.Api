using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Requests;

/// <summary>
/// Request to update an existing meeting.
/// </summary>
public class UpdateMeetingRequest
{
	/// <summary>
	/// Gets or sets the meeting subject.
	/// </summary>
	[JsonPropertyName("subject")]
	public string? Subject { get; set; }

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
}
