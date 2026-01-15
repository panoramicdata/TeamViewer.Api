namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Represents a meeting participant.
/// </summary>
public class MeetingParticipant
{
	/// <summary>
	/// Gets or sets the participant's email.
	/// </summary>
	[JsonPropertyName("email")]
	public string? Email { get; set; }

	/// <summary>
	/// Gets or sets the participant's name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the participant's role.
	/// </summary>
	[JsonPropertyName("role")]
	public string? Role { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the participant is the organizer.
	/// </summary>
	[JsonPropertyName("is_organizer")]
	public bool IsOrganizer { get; set; }

	/// <summary>
	/// Gets or sets the participant's response status.
	/// </summary>
	[JsonPropertyName("response_status")]
	public string? ResponseStatus { get; set; }
}
