using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Response containing SSO access list (exclusion or inclusion).
/// </summary>
public class SsoAccessListResponse
{
	/// <summary>
	/// Gets or sets the list of emails.
	/// </summary>
	[JsonPropertyName("emails")]
	public List<string> Emails { get; set; } = [];
}
