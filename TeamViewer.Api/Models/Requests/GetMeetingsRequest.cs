namespace TeamViewer.Api.Models.Requests;

/// <summary>
/// Request parameters for getting meetings.
/// </summary>
public class GetMeetingsRequest
{
	/// <summary>
	/// Gets or sets the meeting state filter (scheduled, running, ended).
	/// </summary>
	[AliasAs("state")]
	public string? State { get; set; }

	/// <summary>
	/// Gets or sets the owner user ID filter.
	/// </summary>
	[AliasAs("ownerid")]
	public string? OwnerId { get; set; }
}
