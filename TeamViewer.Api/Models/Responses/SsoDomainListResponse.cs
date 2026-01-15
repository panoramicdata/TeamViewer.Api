using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Response containing a list of SSO domains.
/// </summary>
public class SsoDomainListResponse
{
	/// <summary>
	/// Gets or sets the list of SSO domains.
	/// </summary>
	[JsonPropertyName("Domains")]
	public List<SsoDomain> Domains { get; set; } = [];
}
