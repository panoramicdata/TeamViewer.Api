using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Requests;

/// <summary>
/// Request to add or remove emails from SSO access list.
/// </summary>
public class SsoAccessListRequest
{
	/// <summary>
	/// Gets or sets the list of emails. Required.
	/// </summary>
	[JsonPropertyName("emails")]
	public required List<string> Emails { get; set; }
}
