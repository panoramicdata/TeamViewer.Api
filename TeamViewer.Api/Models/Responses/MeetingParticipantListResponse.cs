namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Response containing a list of meeting participants.
/// </summary>
public class MeetingParticipantListResponse
{
	/// <summary>
	/// Gets or sets the list of participants.
	/// </summary>
	[JsonPropertyName("participants")]
	public List<MeetingParticipant> Participants { get; set; } = [];
}
