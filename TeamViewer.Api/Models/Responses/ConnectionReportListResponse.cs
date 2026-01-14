using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Response containing a list of connection reports.
/// </summary>
public class ConnectionReportListResponse
{
	/// <summary>
	/// Gets or sets the list of connection reports.
	/// </summary>
	[JsonPropertyName("records")]
	public List<ConnectionReport> Records { get; set; } = [];
}
