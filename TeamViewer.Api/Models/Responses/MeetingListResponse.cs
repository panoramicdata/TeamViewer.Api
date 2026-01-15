namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Response containing a list of meetings.
/// </summary>
public class MeetingListResponse
{
	/// <summary>
	/// Gets or sets the list of meetings.
	/// </summary>
	[JsonPropertyName("meetings")]
	public List<Meeting> Meetings { get; set; } = [];
}
