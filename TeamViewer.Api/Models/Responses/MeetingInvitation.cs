using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Represents a meeting invitation email content.
/// </summary>
public class MeetingInvitation
{
	/// <summary>
	/// Gets or sets the meeting ID.
	/// </summary>
	[JsonPropertyName("meeting_id")]
	public string? MeetingId { get; set; }

	/// <summary>
	/// Gets or sets the invitation subject.
	/// </summary>
	[JsonPropertyName("subject")]
	public string? Subject { get; set; }

	/// <summary>
	/// Gets or sets the invitation body text.
	/// </summary>
	[JsonPropertyName("body")]
	public string? Body { get; set; }

	/// <summary>
	/// Gets or sets the invitation body as HTML.
	/// </summary>
	[JsonPropertyName("body_html")]
	public string? BodyHtml { get; set; }

	/// <summary>
	/// Gets or sets the meeting URL.
	/// </summary>
	[JsonPropertyName("meeting_url")]
	public string? MeetingUrl { get; set; }
}
