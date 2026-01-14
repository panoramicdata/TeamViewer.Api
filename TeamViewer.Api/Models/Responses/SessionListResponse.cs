using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Response containing a list of sessions.
/// </summary>
public class SessionListResponse
{
	/// <summary>
	/// Gets or sets the list of sessions.
	/// </summary>
	[JsonPropertyName("sessions")]
	public List<Session> Sessions { get; set; } = [];
}
