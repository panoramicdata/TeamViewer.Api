namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Response containing a list of WebConnector sessions.
/// </summary>
public class WebConnectorSessionListResponse
{
	/// <summary>
	/// Gets or sets the list of WebConnector sessions.
	/// </summary>
	[JsonPropertyName("sessions")]
	public List<WebConnectorSession> Sessions { get; set; } = [];
}
